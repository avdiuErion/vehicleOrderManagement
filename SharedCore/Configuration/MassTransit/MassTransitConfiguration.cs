using Microsoft.Extensions.Configuration;

namespace SharedCore.Configuration.MassTransit;

public class MassTransitConfiguration(IConfiguration configuration)
{
    public RabbitMqConfiguration RabbitMq { get; } = new(configuration.GetSection("MassTransit:RabbitMq"));
}

public class RabbitMqConfiguration
{
    public string Url { get; }
    public string Port { get; }

    public string UserName { get; }
    public string Password { get; }

    public RabbitMqConfiguration(IConfiguration configuration)
    {
        Url = configuration["Url"];
        Port = configuration["Port"];
        UserName = configuration["UserName"];
        Password = configuration["Password"];
    }
}