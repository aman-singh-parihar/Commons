namespace BMS.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request details
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            // Call the next middleware in the pipeline
            await _next(context);
            // Log the response details
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
