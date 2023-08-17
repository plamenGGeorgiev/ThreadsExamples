namespace ThreadsExamples;

public class RaceConditionExample: IExample
{
    int result = 0;
    List<int> results = new List<int>();

    void Work1() { result = 1; results.Add(1); }
    void Work2() { result = 2; results.Add(2); }
    void Work3() { result = 3; results.Add(3); }

    public void Example()
    {
        Thread worker1 = new Thread(Work1);
        Thread worker2 = new Thread(Work2);
        Thread worker3 = new Thread(Work3);
        worker1.Start();
        worker2.Start();
        worker3.Start();
        Console.WriteLine(result);

        foreach (int i in results)
        {
            Console.WriteLine(i);
        }

        Console.Read();
    }
}
