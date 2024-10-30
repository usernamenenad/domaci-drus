namespace Domaci2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Philosopher> philosophers = new(5);
            Queue<Fork> forks = new(5);

            for (int i = 0; i < 5; i++)
            {
                forks.Enqueue(new Fork()
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

            SemaphoreSlim semaphore = new(initialCount:2, maxCount:2);

            Parallel.ForEach(philosophers, (philosopher) =>
            {
                while (true)
                {
                    philosopher.Thinking();

                    Console.WriteLine($"Philosopher {philosopher.Id} wants to eat now!");

                    semaphore.Wait();

                    Fork LeftFork = forks.Dequeue();
                    Fork RightFork = forks.Dequeue();

                    lock (LeftFork) 
                    {
                        lock (RightFork)
                        {
                            philosopher.Eating(LeftFork, RightFork);
                            forks.Enqueue(RightFork);
                            forks.Enqueue(LeftFork);
                        }
                    }

                    semaphore.Release();

                    Console.WriteLine($"Philosopher {philosopher.Id} finished eating!");
                }
            });
        }
    }
}
