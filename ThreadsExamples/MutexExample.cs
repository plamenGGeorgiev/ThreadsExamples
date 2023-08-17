namespace ThreadsExamples;

public class MutexExample: IExample
{
    public void Example()
    {
        using (Mutex mutex = new Mutex(false, "MutexDemo"))
        {
            while (true)
            {
                //Checking if Other External Thread is Running
                if (!mutex.WaitOne(5000, false))
                {
                    Console.WriteLine("An Instance of the Application is Already Running");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("Application Is Running.......");
                Console.ReadKey();
                mutex.ReleaseMutex();
                return;
            }
        }
    }
}
