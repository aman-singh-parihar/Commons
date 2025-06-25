public class DeadlockByLocks
{
    object lockObjectA = new object();
    object lockObjectB = new object();
    public void RunExperimentASolution()
    {
        lock (lockObjectA)
        {
            Console.WriteLine("Acquired lock on A");
            Task.Delay(100);
            
            Thread.Sleep(1000); // Simulate some work
            lock (lockObjectB)
            {
                Console.WriteLine("Acquired lock on B");
            }
        }
    }

    public void RunExperimentBSolution()
    {
        lock (lockObjectA)
        {
            Console.WriteLine("Acquired lock on A");
            Thread.Sleep(1000);
            lock (lockObjectB)
            {
                Console.WriteLine("Acquired lock on B");
            }
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        DeadlockByLocks experiment = new DeadlockByLocks();
        Thread threadA = new Thread(experiment.RunExperimentASolution);
        Thread threadB = new Thread(experiment.RunExperimentBSolution);

        threadA.Start();
        threadB.Start();

        threadA.Join();
        threadB.Join();
        Console.WriteLine("Completed");
    }
}
