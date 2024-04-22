using MassTransit;
using SharedCore.Events.Engine;

namespace NotificationService.ApplicationService.Consumers;

public class ChassisProductionStartedEventConsumer : IConsumer<EngineProductionStartEvent>
{
    public Task Consume(ConsumeContext<EngineProductionStartEvent> context)
    {
        throw new NotImplementedException();
    }
}