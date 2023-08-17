namespace ThreadsExamples;

public class SpinLockExample: IExample
{
    SpinLock spLock = new SpinLock();

    private void OutsideProcess()
    {
        bool lockTaken = false;
        try
        {
            spLock.Enter(ref lockTaken);
            Thread.Sleep(1000);
            InsideProccess();
            Console.WriteLine("OutsideProcess method acquire the lock::");
        }
        finally
        {
            if (lockTaken) spLock.Exit();
            Console.WriteLine("OutsideProcess method Release the lock::");
        }
    }

    private void InsideProccess()
    {
        bool lockTaken = false;
        try
        {
            if (!spLock.IsHeldByCurrentThread) spLock.Enter(ref lockTaken);
            Console.WriteLine("InsideProccess method acquire the lock::");
        }
        finally
        {
            if (lockTaken) spLock.Exit();
            Console.WriteLine("InsideProccess method Release the lock::");
        }
    }
    public void Example()
    {
        Thread th = new Thread(new ThreadStart(OutsideProcess));
        th.Start();
        Console.Read();
    }
}
