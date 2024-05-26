using Microsoft.AspNetCore.Http;

namespace Source.Shared.Extensions.Middlewares;

public class ExampleCustomMiddleware
{
    private readonly RequestDelegate _next; 
    
    public ExampleCustomMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Logic before handling the request
        // For example:
        // Console.WriteLine("Before handling the request...");

        await _next(context); // Passing the request to the next middleware

        // Logic after handling the request
        // For example:
        // Console.WriteLine("After handling the request...");
    }
}
