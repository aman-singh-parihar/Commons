namespace ClientAPICalls
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(5));
            await LongRunningTask(100, cts.Token);
        }
        static async Task LongRunningTask(int count, CancellationToken cancellation) 
        {
            Console.WriteLine("\nLongRunningTask Started");
            for (int i = 0; i < count; i++) 
            { 
                await Task.Delay(1000);
                Console.WriteLine("LongRunningTask Processing....");
                if (cancellation.IsCancellationRequested) 
                {
                    throw new TaskCanceledException();
                }
            }
            Console.WriteLine("\nLongRunningTask Completed");
        }
    }
}
