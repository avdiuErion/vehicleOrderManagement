using Microsoft.AspNetCore.Http;

namespace SharedCore.Middlewares;

public class RequestCorrelationMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        // Generate a unique correlation ID for the request
        string correlationId = Guid.NewGuid().ToString();

        // Add the correlation ID to the response headers
        context.Response.Headers["X-Correlation-ID"] = correlationId;

        // Pass the request to the next middleware
        await next(context);
    }
}