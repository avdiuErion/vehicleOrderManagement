using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SharedCore.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddBaseServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}