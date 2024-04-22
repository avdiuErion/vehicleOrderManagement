using MassTransit;
using SharedCore.Events.Order;

namespace NotificatioService.ApplicationService.Consumers;

public class OrderReadyEventConsumer : IConsumer<OrderReadyEvent>
{
    public Task Consume(ConsumeContext<OrderReadyEvent> context)
    {
        throw new NotImplementedException();
    }
}