using Microsoft.AspNetCore.Http;

namespace SharedCore.Middlewares;

public class RequestCorrelationMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        string correlationId = Guid.NewGuid().ToString();
        context.Response.Headers["X-Correlation-ID"] = correlationId;

        await next(context);
    }
}