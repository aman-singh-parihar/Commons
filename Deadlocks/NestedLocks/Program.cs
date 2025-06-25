public class DeadlockByLocks
{
    object lockObjectA = new object();
    object lockObjectB = new object();

    public void RunExperimentA() 
    {
        lock (lockObjectA) 
        {
            Task.Delay(100);
            Console.WriteLine("Acquired lock on A");
            Thread.Sleep(1000); // Simulate some work
            lock (lockObjectB)
            {
                Console.WriteLine("Will Never execute");
            }
        }
    }

    public void ExperimentB() 
    {
        lock (lockObjectB) 
        {
            Console.WriteLine("Acquired lock on B");
            Thread.Sleep(1000);
            lock (lockObjectA) 
            {
                Console.WriteLine("Will Never execute");
            }
        }
    }
}

//Consumer
internal class Program
{
    static void Main(string[] args)
    {
        DeadlockByLocks experiment = new DeadlockByLocks();
        Thread threadA = new Thread(experiment.RunExperimentA);
        Thread threadB = new Thread(experiment.ExperimentB);

        threadA.Start();
        threadB.Start();

        threadA.Join();
        threadB.Join();
        Console.WriteLine("Completed");
    }
}
