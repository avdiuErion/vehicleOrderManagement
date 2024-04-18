using Microsoft.AspNetCore.Builder;
using SharedCore.Middlewares;

namespace SharedCore.Configuration;

public static class DefaultWebAppConfiguration
{
    public static void AddSharedConfiguration(this WebApplication app)
    {
        app.UseMiddleware<RequestCorrelationMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();
    }
}