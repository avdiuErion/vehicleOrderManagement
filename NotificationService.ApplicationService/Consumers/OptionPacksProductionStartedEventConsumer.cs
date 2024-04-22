using MassTransit;
using SharedCore.Events.OptionPacks;

namespace NotificationService.ApplicationService.Consumers;

public class OptionPacksProductionStartedEventConsumer : IConsumer<OptionPacksProductionStartEvent>
{
    public Task Consume(ConsumeContext<OptionPacksProductionStartEvent> context)
    {
        throw new NotImplementedException();
    }
}