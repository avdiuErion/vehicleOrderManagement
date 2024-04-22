using MassTransit;
using SharedCore.Events.OptionPacks;

namespace WarehouseService.ApplicationService.Consumers.OptionPacks;

public class OptionPacksProductionCompleteEventConsumer : IConsumer<OptionPacksProductionCompleteEvent>
{
    public Task Consume(ConsumeContext<OptionPacksProductionCompleteEvent> context)
    {
        throw new NotImplementedException();
    }
}