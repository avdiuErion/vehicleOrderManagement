using System.Net;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace SharedCore.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An unhandled exception occurred. {CorrelationId} {RequestMethod} {RequestPath}",
                context.TraceIdentifier, context.Request.Method, context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(exception.Message);
    }
}