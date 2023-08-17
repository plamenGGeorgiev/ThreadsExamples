namespace ThreadsExamples;

public class ReaderWriterLockSlimExample: IExample
{

    static ReaderWriterLockSlim rw = new ReaderWriterLockSlim();
    static List<int> items = new List<int>();
    static Random rand = new Random();

    public void Example()
    {
        new Thread(Read).Start();
        new Thread(Read).Start();
        new Thread(Read).Start();
        new Thread(Write).Start("A");
        new Thread(Write).Start("B");
        Console.Read();
    }

    private void Read()
    {
        while (true)
        {
            rw.EnterReadLock();
            foreach (int i in items) Thread.Sleep(2000);
            rw.ExitReadLock();
        }
    }

    private void Write(object threadID)
    {
        while (true)
        {
            int newNumber = GetRandNum(50);
            rw.EnterWriteLock();
            items.Add(newNumber);
            rw.ExitWriteLock();
            Console.WriteLine("Thread " + threadID + " added " + newNumber);
            Thread.Sleep(100);
        }
    }

    private int GetRandNum(int max)
    {
        lock (rand)
            return rand.Next(max);
    }
}
