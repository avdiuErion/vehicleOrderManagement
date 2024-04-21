using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SharedCore.Middlewares;

namespace SharedCore.Configuration;

public static class DefaultWebAppConfiguration
{
    public static void AddSharedConfiguration(this WebApplication app)
    {
        app.UseMiddleware<RequestCorrelationMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();
    }
    
    public static void AddBaseInfrastructureServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof (services));
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        services.AddControllers().AddDataAnnotationsLocalization().AddJsonOptions((options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.Converters.Add( new JsonStringEnumConverter());
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        }));
    }
}