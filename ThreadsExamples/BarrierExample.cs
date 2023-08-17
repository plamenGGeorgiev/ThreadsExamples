namespace ThreadsExamples;

public class BarrierExample : IExample
{
    private Barrier barrier = new Barrier(participantCount: 5);
    public void Example()
    {
        Task[] tasks = new Task[5];

        for (int i = 0; i < 5; ++i)
        {
            int j = i;
            tasks[j] = Task.Factory.StartNew(() =>
            {
                GetDataAndStoreData(j);
            });
        }

        Task.WaitAll(tasks);

        Console.WriteLine("Backup completed");
        Console.ReadLine();


    }

    private void GetDataAndStoreData(int index)
    {
        Console.WriteLine("Getting data from server: " + index);
        Thread.Sleep(TimeSpan.FromSeconds(2));

        barrier.SignalAndWait();

        Console.WriteLine("Send data to Backup server: " + index);

        barrier.SignalAndWait();
    }
}
