using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace SharedCore.Configuration.MassTransit;

public static class MassTransitConfigurator
{
    public static void ConfigureMassTransit(this IServiceCollection services, MassTransitConfiguration configuration,
        Assembly assembly)
    {
        var consumerTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && typeof(IConsumer).IsAssignableFrom(type));

        services.AddMassTransit(config =>
        {
            foreach (var consumerType in consumerTypes)
            {
                config.AddConsumer(consumerType);
            }

            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.RabbitMq.Url, configuration.RabbitMq.Port, h =>
                {
                    h.Username(configuration.RabbitMq.UserName);
                    h.Password(configuration.RabbitMq.Password);
                });

                foreach (var consumerType in consumerTypes)
                {
                    cfg.ReceiveEndpoint(consumerType.Name.ToLower() + "_queue",
                        ep => { ep.ConfigureConsumer(context, consumerType); });
                }
            });
        });
    }
}