namespace ThreadsExamples;

public class LockExample: IExample
{
    public void Example()
    {
        Thread t1 = new Thread(DisplayMessage);
        Thread t2 = new Thread(DisplayMessage);
        Thread t3 = new Thread(DisplayMessage);
        t1.Start();
        t2.Start();
        t3.Start();
        Console.Read();
    }

    private readonly object LockDisplayMethod = new object();
    private void DisplayMessage()
    {
        lock (LockDisplayMethod)
        {
            Console.Write("[Welcome to the ");
            Thread.Sleep(1000);
            Console.WriteLine("world of dotnet!]");
        }
    }
}
