namespace Domaci2._1
{
    internal class Philosopher
    {
        public int Id;

        public void Thinking()
        {
            Console.WriteLine($"Philosopher {Id} is thinking now...");
            Thread.Sleep(2000);
        }

        public void Eating(Fork LeftFork, Fork RightFork)
        {
            Console.WriteLine($"Philosopher {Id} is eating with left fork {LeftFork.Id} and right fork {RightFork.Id} now...");
            Thread.Sleep(3000);
        }
    }
}
