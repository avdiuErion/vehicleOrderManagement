using MassTransit;
using SharedCore.Events.Engine;

namespace WarehouseService.ApplicationService.Consumers.Engine;

public class EngineProductionCompleteEventConsumer : IConsumer<EngineProductionCompleteEvent>
{
    public Task Consume(ConsumeContext<EngineProductionCompleteEvent> context)
    {
        throw new NotImplementedException();
    }
}