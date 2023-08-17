using System.Collections.Concurrent;

namespace ThreadsExamples;

public class ConcurrentCollectionsExamples : IExample
{
    static Dictionary<int, string> dictionary = new Dictionary<int, string>();

    static ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();

    public void Example()
    {
            Thread t1 = new Thread(Method1);
            Thread t2 = new Thread(Method2);
            t1.Start();
            t2.Start();
            Console.ReadKey();

            Thread t3 = new Thread(Method1);
            Thread t4 = new Thread(Method2);
            t3.Start();
            t4.Start();
            t3.Join();
            t4.Join();
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
            }
            Console.ReadKey();
    }
    public static void Method1()
    {
        for (int i = 0; i < 10; i++)
        {
            dictionary.Add(i, "Added By Method1 " + i);
            Thread.Sleep(100);
        }
    }
    public static void Method2()
    {
        for (int i = 0; i < 10; i++)
        {
            dictionary.Add(i, "Added By Method2 " + i);
            Thread.Sleep(100);
        }
    }
}
