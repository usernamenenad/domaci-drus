using System.Diagnostics;

namespace Domaci1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 1_000_000;
            List<int> numbers = CreateList(size);

            //int numberOfThreads = 2;
            //TestSyncVsAsync(size, numbers, numberOfThreads);

            //List<int> testNumbers = [2, 5, 10, 50, 100, 1000000];
            //TestAsync(size, numbers, testNumbers);

            //List<int> degreesOfParallelism = [2, 5, 10, 50, 100];
            //TestParallel(size, numbers, degreesOfParallelism);
        }

        static (double, double) MeasureMeanSync(int size, List<int> numbers) 
        {
            double mean = 0;

            Stopwatch sw = Stopwatch.StartNew();
            foreach(int i in numbers)
            {
                mean += (double)i / (double)size;
            }
            sw.Stop();

            return (mean, sw.ElapsedMilliseconds);
        }

        static async Task<(double, double)> MeasureMeanAsync(int size, List<int> numbers, int numberOfThreads)
        {
            int ratio = size / numberOfThreads;
            Task<double>[] tasks = new Task<double>[numberOfThreads];

            Stopwatch sw = Stopwatch.StartNew();
            for(int i = 0; i < numberOfThreads; i++)
            {
                // Za svaku iteraciju, mora se napraviti specijalna promjenljiva "j"
                // čiji je životni vijek isključivo u petlji, jer bi se u Task.Run delegatu
                // samo prosljeđivanje promjenljive "i" bilo po referenci.
                var j = i; 

                tasks[i] = Task.Run(() =>
                {
                    double sum = 0;
                    foreach(int k in numbers[(j * ratio)..((j + 1) * ratio)])
                    {
                        sum += k;
                    }
                    return (double)sum / (double)size;
                });
            }

            double[] results = await Task.WhenAll(tasks);
            double mean = results.Sum();
            sw.Stop();

            return (mean, sw.ElapsedMilliseconds);
        }

        public static (double, double) MeasureMeanParallel(int size, List<int> numbers, int degreeOfParallelism)
        {
            int ratio = size / numbers.Count;
            double mean = 0;

            ParallelOptions parallelOptions = new()
            {
                MaxDegreeOfParallelism = degreeOfParallelism,
            };

            Stopwatch sw = Stopwatch.StartNew();
            Parallel.For(0, size, (index) =>
            {
                lock(numbers)
                {
                    mean += (double)numbers[index] / (double)size;
                }
            });
            sw.Stop();

            return (mean, sw.ElapsedMilliseconds);
        }

        public static List<int> CreateList(int size)
        {
            Random random = new();
            Console.WriteLine($"Inicijalizacija liste veličine {size} brojeva...");

            List<int> numbers = Enumerable.Range(0, size).Select(i => random.Next(0, 100)).ToList();

            Console.WriteLine("Završeno!");
            Console.WriteLine("-------------------------------");

            return numbers;
        }

        public static void TestSyncVsAsync(int size, List<int> numbers, int numberOfThreads)
        {
            Console.WriteLine("Startovanje sinhrone operacije...");
            var (MeanSync, ElapsedTimeSync) = MeasureMeanSync(size, numbers);
            Console.WriteLine($"Vrijeme potrebno za sinhrono računanje: {ElapsedTimeSync} milisekundi.");
            Console.WriteLine($"Srednja vrijednost računata sinhrono jednaka je {MeanSync:F2}.");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Startovanje asinhrone operacije...");
            var (MeanAsync, ElapsedTimeAsync) = MeasureMeanAsync(size, numbers, numberOfThreads).Result;
            Console.WriteLine($"Vrijeme potrebno za asinhrono računanje (sa {numberOfThreads} niti): {ElapsedTimeAsync} milisekundi.");
            Console.WriteLine($"Srednja vrijednost računata asinhrono jednaka je {MeanAsync:F2}.");
            Console.WriteLine("-------------------------------");
        }

        public static void TestAsync(int size, List<int> numbers, List<int> testNumbers)
        {
            Console.WriteLine("Početak testiranja asinhronog računanja...");
            Console.WriteLine("-------------------------------");

            foreach (int numberOfThreads in testNumbers)
            {
                Console.WriteLine($"Testiranje sa {numberOfThreads} niti...");
                List<double> ElapsedTimes = [];

                string filePath = $"threads_{numberOfThreads}.txt";
                using StreamWriter sw = new(filePath, true);

                // Broj puta koji ćemo testirati
                int TimesTesting = 5;
                for(int i = 0; i < TimesTesting; i++)
                {
                    var (_, ElapsedTime) = MeasureMeanAsync(size, numbers, numberOfThreads).Result;
                    Console.WriteLine($"Testiranje broj {i + 1} u toku...");
                    ElapsedTimes.Add(ElapsedTime);
                    sw.WriteLine($"Vrijeme izvršavanja broj {i + 1}: {ElapsedTime} milisekundi.");
                }

                sw.WriteLine($"Prosječno vrijeme izvršavanja: {ElapsedTimes.Sum() / TimesTesting} milisekundi.");
                Console.WriteLine($"Rezultati za testiranje sa {numberOfThreads} niti nalaze se u {filePath}!");
                Console.WriteLine("-------------------------------");
            }
        }

        public static void TestParallel(int size, List<int> numbers, List<int> degreesOfParallelism)
        {
            Console.WriteLine("Početak testiranja paralelnog računanja...");
            Console.WriteLine("-------------------------------");

            foreach (int degreeOfParallelism in degreesOfParallelism)
            {
                Console.WriteLine($"Testiranje sa {degreeOfParallelism}. stepenom paralelizma...");
                List<double> ElapsedTimes = [];

                string filePath = $"parallel_{degreeOfParallelism}.txt";
                using StreamWriter sw = new(filePath, true);

                // Broj puta koji ćemo testirati
                int TimesTesting = 5;
                for (int i = 0; i < TimesTesting; i++)
                {
                    var (_, ElapsedTime) = MeasureMeanAsync(size, numbers, degreeOfParallelism).Result;
                    Console.WriteLine($"Testiranje broj {i + 1} u toku...");
                    ElapsedTimes.Add(ElapsedTime);
                    sw.WriteLine($"Vrijeme izvršavanja broj {i + 1}: {ElapsedTime} milisekundi.");
                }

                sw.WriteLine($"Prosječno vrijeme izvršavanja: {ElapsedTimes.Sum() / TimesTesting} milisekundi.");
                Console.WriteLine($"Rezultati za testiranje sa {degreeOfParallelism}. stepenom paralelizma nalaze se u {filePath}!");
                Console.WriteLine("-------------------------------");
            }
        }
    }
}
