using ServiceReference;

namespace LotoMachine
{
    internal class Program
    {
        static PublisherClient PublisherClient = new();
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("Loto mašina izvlači brojeve...");
                (int FirstNumber, int SecondNumber) = GetNumbers();

                Console.WriteLine($"Izvučeni brojevi su {FirstNumber} i {SecondNumber}.");
                Console.WriteLine("-----------------------------------------------------");
                
                PublisherClient.Publish(FirstNumber, SecondNumber);

                Thread.Sleep(1000 * 5);
            }
        }

        static (int, int) GetNumbers()
        {
            Thread.Sleep(1000);
            Random random = new();
            return (random.Next(0, 10), random.Next(0, 10));
        }
    }
}
