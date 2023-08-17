namespace ThreadsExamples;

public class MonitorExample: IExample
{
    private readonly object lockPrintNumbers = new object();
    private void PrintNumbers()
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
        bool lockTaken = false;
        try
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section");
            Monitor.TryEnter(lockPrintNumbers, timeout, ref lockTaken);
            if (lockTaken)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                for (int i = 0; i < 5; i++)
                {
                    //Thread.Sleep(100); // to show behavior
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Lock was not acquired");
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(lockPrintNumbers);
                Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
            }
        }
    }
    public void Example()
    {
        Thread[] Threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            Threads[i] = new Thread(PrintNumbers)
            {
                Name = "Child Thread " + i
            };
        }
        foreach (Thread t in Threads)
        {
            t.Start();
        }
        Console.ReadLine();
    }
}
