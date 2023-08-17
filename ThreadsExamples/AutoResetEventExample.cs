namespace ThreadsExamples;

public class AutoResetEventExample: IExample
{
    private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    public void Example()
    {
        Thread newThread = new Thread(SomeMethod)
        {
            Name = "NewThread"
        };
        newThread.Start();

        Console.ReadLine();

        autoResetEvent.Set();
    }
    private void SomeMethod()
    {
        Console.WriteLine("Starting........");
        autoResetEvent.WaitOne();
        Console.WriteLine("Finishing........");
    }
}
