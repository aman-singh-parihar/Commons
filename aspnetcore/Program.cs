namespace aspnetcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             CreateBuilder is a static method that initializes a new instance of the WebApplicationBuilder class.
             CreateBuiler takes args as an argument, which is typically passed to the constructor of the WebApplicationOptions.
                public static WebApplicationBuilder CreateBuilder(string[] args) => new WebApplicationBuilder(new WebApplicationOptions() { Args = args });

            A lot of things happening in the WebApplicationBuilder constructor.
            - Initializes the configuration system, which includes loading configuration settings from various sources (like appsettings.json, environment variables, command line etc.).
            - Initializes the default logging (console, debug, event log etc).


            builder object will have access of Services, Logging, Configuration, Environment, and Host.
             */
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            async Task m1()
            {
                Console.WriteLine("Hello from the m1!");
                await Task.CompletedTask;
            }

            async Task m2(HttpContext context, Func<Task> m1)
            {
                Console.WriteLine("Hello from the middleware!");
                /*
                 If we think that m1 will be called here then we are wrong. 
                 because m1 will be passed by the aspnetcore framework, which is the next middleware in the pipeline.
                so, we are awaiting on m1 here, which is the next middleware in the pipeline, not the m1 defined above.
                 */
                await m1();
                Console.WriteLine("Hello from the middleware!!!!!");
            }

            app.Use(m2);

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
