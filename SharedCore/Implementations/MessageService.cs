using MassTransit;
using SharedCore.Interfaces;

namespace SharedCore.Implementations;

public class MessageService(IBus bus) : IMessageService
{
    public async Task PublishEvent<TEvent>(TEvent @event) where TEvent : class
    {
        await bus.Publish(@event);
    }
}