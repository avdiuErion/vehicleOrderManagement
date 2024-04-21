using MassTransit;
using Microsoft.Extensions.Configuration;

namespace SharedCore.Configuration.MassTransit;

public class BusConfigurationBase(IConfiguration configuration) : IBusConfiguration
{
    private readonly IConfiguration _configuration = configuration.GetSection("MassTransit:Bus");

    public virtual void Configure(IRabbitMqBusFactoryConfigurator cfg)
    {
        var endpoints = _configuration.GetSection("Endpoints").GetChildren();

        foreach (var endpoint in endpoints)
        {
            var exchange = endpoint["Exchange"];
            var queue = endpoint["Queue"];
            var bindingKey = endpoint["BindingKey"];
            
            cfg.ReceiveEndpoint(queue, endpoint =>
            {
                endpoint.Bind(exchange, binding => binding.RoutingKey = bindingKey);
            });
        }
    }
}