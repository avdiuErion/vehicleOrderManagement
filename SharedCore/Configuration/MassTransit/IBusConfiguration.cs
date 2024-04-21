using MassTransit;

namespace SharedCore.Configuration.MassTransit;

public interface IBusConfiguration
{
    void Configure(IRabbitMqBusFactoryConfigurator cfg);
}