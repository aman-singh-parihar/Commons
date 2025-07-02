
using BMS.Middlewares;

namespace BMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddOpenApi();
            
            var app = builder.Build();
            app.UseLoggingMiddleware();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapGet("/book", (HttpContext httpContext) =>
            {
                Console.WriteLine("Booking a ticket...");
            })
            .WithName("BookTicket");

            app.Run();
        }
    }
}
