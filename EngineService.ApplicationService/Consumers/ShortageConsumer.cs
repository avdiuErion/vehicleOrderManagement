using MassTransit;
using SharedCore.Events;

namespace EngineService.ApplicationService.Consumers;

public class ShortageConsumer : IConsumer<ShortageEvent>
{
    public Task Consume(ConsumeContext<ShortageEvent> context)
    {
        ShortageEvent message = context.Message;
        Console.WriteLine("Message consumed");
        return null;
    }
}