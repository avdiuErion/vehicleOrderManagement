using MassTransit;
using SharedCore.Events.Engine;

namespace NotificatioService.ApplicationService.Consumers;

public class EngineProductionStartedEventConsumer : IConsumer<EngineProductionStartEvent>
{
    public Task Consume(ConsumeContext<EngineProductionStartEvent> context)
    {
        throw new NotImplementedException();
    }
}