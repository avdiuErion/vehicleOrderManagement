using ChassisService.Domain.Entitites;
using ChassissService.DataAccess.Interfaces;
using MassTransit;
using SharedCore.Enums;
using SharedCore.Events;
using SharedCore.Events.Chassis;
using SharedCore.Events.Order;
using SharedCore.Interfaces;

namespace ChassisService.ApplicationService.Consumers;

public class ShortageConsumer(IChassisOrderRepository chassisOrderRepository, IMessageService messageService) : IConsumer<ShortageEvent>
{
    public async Task Consume(ConsumeContext<ShortageEvent> context)
    {
        ShortageEvent message = context.Message;

        IEnumerable<ShortageItem> items = message.ShortageItems.Where(x => x.Type == ProductType.Engine).ToList();

        foreach (var item in items)
        {
            ChassisOrder newOrder = new ChassisOrder()
            {
                ProductionState = ProductionState.Started,
                ChassisId = item.ProductId
            };
                
            await chassisOrderRepository.AddAsync(newOrder);
            await messageService.PublishEvent(new ChassisProductionStartEvent()
            {
                ChassisOrderId = newOrder.Id,
                OrderId = message.OrderId
            });
        }
    }
}