using EngineService.DataAccess.Interfaces;
using EngineService.Domain.Entities;
using MassTransit;
using SharedCore.Enums;
using SharedCore.Events;
using SharedCore.Events.Engine;
using SharedCore.Events.Order;
using SharedCore.Interfaces;

namespace EngineService.ApplicationService.Consumers;

public class ShortageConsumer(IEngineOrderRepository engineOrderRepository, IMessageService messageService)
    : IConsumer<ShortageEvent>
{
    public async Task Consume(ConsumeContext<ShortageEvent> context)
    {
        ShortageEvent message = context.Message;

        IEnumerable<ShortageItem> items = message.ShortageItems.Where(x => x.Type == ProductType.Engine).ToList();

        foreach (var item in items)
        {
            EngineOrder newOrder = new EngineOrder()
            {
                ProductionState = ProductionState.Started,
                EngineId = item.ProductId
            };
                
            await engineOrderRepository.AddAsync(newOrder);
            await messageService.PublishEvent(new EngineProductionStartEvent()
            {
                EngineOrderId = newOrder.Id,
                OrderId = message.OrderId
            });
        }
    }
}