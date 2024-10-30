namespace Domaci2._1
{
    internal class Fork
    {
        public int Id;
        public SemaphoreSlim Semaphore = new(initialCount: 1, maxCount: 1);
    }
}
