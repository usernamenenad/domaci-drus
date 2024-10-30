namespace Domaci2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Philosopher> philosophers = new(5);
            List<Fork> forks = new(5);

            for (int i = 0; i < 5; i++)
            {
                forks.Add(new Fork()
                {
                    Id = i
                });
            }

            for (int i = 0; i < 5; i++)
            {
                philosophers.Add(new Philosopher()
                {
                    Id = i
                });
            }

            Parallel.ForEach(philosophers, (philosopher) =>
            {
                while (true)
                {
                    philosopher.Thinking();

                    Console.WriteLine($"Philosopher {philosopher.Id} wants to eat now!");

                    Fork LeftFork = forks[philosopher.Id];
                    Fork RightFork = forks[philosopher.Id - 1 >= 0 ? philosopher.Id - 1 : ^1];

                    LeftFork.Semaphore.Wait();
                    RightFork.Semaphore.Wait();

                    philosopher.Eating(LeftFork, RightFork);

                    RightFork.Semaphore.Release();
                    LeftFork.Semaphore.Release();

                    Console.WriteLine($"Philosopher {philosopher.Id} finished eating!");
                }
            });
        }
    }
}
