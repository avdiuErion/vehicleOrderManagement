using MassTransit;
using SharedCore.Configuration.MassTransit;
using ExchangeType = RabbitMQ.Client.ExchangeType;

namespace OrderService.WebAPI.Configuration;

public class BusConfiguration(IConfiguration configuration) : IBusConfiguration
{
    private readonly IConfiguration _configuration = configuration.GetSection("MassTransit:Bus");

    public void Configure(IRabbitMqBusFactoryConfigurator cfg)
    {
        var endpoints = _configuration.GetSection("Endpoints").GetChildren();

        foreach (var endpoint in endpoints)
        {
            var exchange = endpoint["Exchange"];
            var queue = endpoint["Queue"];
            var bindingKey = endpoint["BindingKey"];
            
            cfg.ReceiveEndpoint(queue, endpoint =>
            {
                endpoint.Bind(exchange);
            });
            
            cfg.AutoStart = true;
        }
    }
}