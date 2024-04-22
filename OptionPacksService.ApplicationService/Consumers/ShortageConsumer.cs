using MassTransit;
using OptionPacksService.DataAccess.Interfaces;
using OptionPacksService.Domain.Entities;
using SharedCore.Enums;
using SharedCore.Events;
using SharedCore.Events.OptionPacks;
using SharedCore.Events.Order;
using SharedCore.Interfaces;

namespace OptionPacksService.ApplicationService.Consumers;

public class ShortageConsumer(IOptionPacksOrderRepository chassisOrderRepository, IMessageService messageService) : IConsumer<ShortageEvent>
{
    public async Task Consume(ConsumeContext<ShortageEvent> context)
    {
        ShortageEvent message = context.Message;

        IEnumerable<ShortageItem> items = message.ShortageItems.Where(x => x.Type == ProductType.Engine).ToList();

        foreach (var item in items)
        {
            OptionPackOrder newOrder = new OptionPackOrder()
            {
                ProductionState = ProductionState.Started,
                OptionPackId = item.ProductId
            };
                
            await chassisOrderRepository.AddAsync(newOrder);
            await messageService.PublishEvent(new OptionPacksProductionStartEvent()
            {
                OptionPacksOrderId = newOrder.Id,
                OrderId = message.OrderId
            });
        }
    }
}