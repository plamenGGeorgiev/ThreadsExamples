namespace ThreadsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IExample example;

            //example = new LockExample();
            //example = new MonitorExample();
            //example = new MutexExample();
            //example = new SemaphorExample();
            //example = new RaceConditionExample();
            //example = new DeadlockExample();
            //example = new ThreadStarvationExample();
            example = new BarrierExample();
            //example = new CountDownEventExample();
            //example = new AutoResetEventExample();
            //example = new ReaderWriterLockSlimExample();
            //example = new SpinLockExample();
            //example = new ConcurrentCollectionsExamples();

            example.Example();

        }
    }
}