namespace ThreadsExamples;

public class SemaphorExample: IExample
{
    private Semaphore semaphore = new Semaphore(2, 3);

    public void Example()
    {
        for (int i = 1; i <= 10; i++)
        {
            Thread threadObject = new Thread(DoSomeTask)
            {
                Name = "Thread " + i
            };
            threadObject.Start();
        }
        Console.ReadKey();
    }

    private void DoSomeTask()
    {
        Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter into Critical Section for processing");
        try
        { 
            semaphore.WaitOne();
            Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
            Thread.Sleep(5000);
            Console.WriteLine(Thread.CurrentThread.Name + "Exit.");
        }
        finally
        {
            semaphore.Release();
        }
    }
}
