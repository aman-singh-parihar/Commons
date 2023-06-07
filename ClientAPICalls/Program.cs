namespace ClientAPICalls
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Some Method Started");
            using (var client = new HttpClient())
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(4000);
                client.BaseAddress = new Uri("http://localhost:58937/");
                try
                {
                    string Name = "James";
                    Console.WriteLine("Some Method Calling Web API");
                    HttpResponseMessage response = await client.GetAsync($"api/greetings/{Name}", cancellationTokenSource.Token);
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine($"Task Execution Cancelled: {ex.Message}");
                }
                Console.WriteLine("Some Method Completed");
            }

            Console.WriteLine("Hello, World!");
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