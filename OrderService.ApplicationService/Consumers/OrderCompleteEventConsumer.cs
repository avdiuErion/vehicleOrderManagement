using MassTransit;
using Microsoft.Extensions.Logging;
using OrderService.DataAccess.Interfaces;
using OrderService.Domain;
using OrderService.Domain.Enums;
using SharedCore.Events.Order;
using SharedCore.Events.Warehouse;
using SharedCore.Interfaces;

namespace OrderService.ApplicationService.Consumers;

public class OrderCompleteEventConsumer(
    IOrderRepository orderRepository,
    ILogger<OrderCompleteEventConsumer> logger,
    IMessageService messageService)
    : IConsumer<OrderCompletedEvent>
{
    public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
    {
        Guid orderId = Guid.Empty;

        try
        {
            orderId = context.Message.OrderId;

            Order? order = await orderRepository.FirstOrDefaultAsync(x => x!.Id == orderId);

            order.Status = OrderStatus.Completed;

            await orderRepository.UpdateAsync(order);

            await messageService.PublishEvent(new OrderReadyEvent()
            {
                OrderId = orderId
            });
        }
        catch (Exception ex)
        {
            logger.LogError("Error completing order {ID}: {error}", orderId, ex.Message);
            throw;
        }
    }
}