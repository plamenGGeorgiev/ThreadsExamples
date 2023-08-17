namespace ThreadsExamples;

public class ThreadStarvationExample : IExample
{
    static object resourceLock = new object();

    public void Example()
    {
        Thread highPriorityThread = new Thread(HighPriorityWork);
        Thread midPriorityThread = new Thread(MidPriorityWork);
        Thread lowPriorityThread = new Thread(LowPriorityWork);

        highPriorityThread.Priority = ThreadPriority.Highest;
        midPriorityThread.Priority = ThreadPriority.Normal;
        lowPriorityThread.Priority = ThreadPriority.Lowest;

        highPriorityThread.Start();
        midPriorityThread.Start();
        lowPriorityThread.Start();

        highPriorityThread.Join();
        midPriorityThread.Join();
        lowPriorityThread.Join();

        Console.WriteLine("Main program completed.");
    }

    private void HighPriorityWork()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("High-priority thread is working.");
            Thread.Sleep(600); // Simulate work
        }
    }

    private void MidPriorityWork()
    {
        lock (resourceLock)
        {
            Console.WriteLine("Mid-priority thread has the lock.");
            Thread.Sleep(3000); // Simulate work
        }
    }

    private void LowPriorityWork()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (resourceLock)
            {
                Console.WriteLine("Low-priority thread has the lock.");
                Thread.Sleep(300); // Simulate work
            }
        }
    }

}
