using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedCore.Configuration;

namespace SharedCore.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBaseServices(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        SerilogConfiguration.ConfigureSerilog();
    }
    
    public static void CoreAddDbContext<T>(this IServiceCollection services,
        Action<DbContextOptionsBuilder>? optionsBuilder = null,
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        where T : DbContext
    {
        services.AddDbContext<T>((serviceProvider, options) =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            optionsBuilder?.Invoke(options);

            if (options.IsConfigured == false)
            {
                options.UseInMemoryDatabase(typeof(T).Name);
            }

            // Use the service provider for internal EF Core services
            options.UseInternalServiceProvider(serviceProvider);
            options.UseApplicationServiceProvider(serviceProvider);
        }, contextLifetime, optionsLifetime);

        // Add Entity Framework In-Memory Database provider
        services.AddEntityFrameworkInMemoryDatabase();
    }
}