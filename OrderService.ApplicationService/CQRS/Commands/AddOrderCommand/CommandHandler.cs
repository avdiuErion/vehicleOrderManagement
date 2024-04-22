using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderService.DataAccess.Interfaces;
using OrderService.Domain;
using SharedCore.Clients.Interfaces;
using SharedCore.Dtos;
using SharedCore.Events.Order;
using SharedCore.Interfaces;

namespace OrderService.ApplicationService.CQRS.Commands.AddOrderCommand;

public class CommandHandler(
    ILogger<CommandHandler> logger,
    IWarehouseClient warehouseClient,
    IMessageService messageService,
    IMapper mapper,
    IOrderRepository orderRepository) : IRequestHandler<Command, CommandResponse>
{
    public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            Guid orderId = Guid.NewGuid();
            List<ShortageItem> shortageItems = new List<ShortageItem>();
            
            logger.LogInformation("Checking existing inventory in Warehouse for Order {ID}", orderId);

            List<StockItemDto>? responseDto = await warehouseClient.GetStockItems();

            if (responseDto != null && responseDto.Any())
            {
                shortageItems = GetShortageItems(request.OrderItems, responseDto);
            }

            if (!shortageItems.Any())
            {
                logger.LogInformation("Publishing {AssembleVehicleEvent} for Order {ID}", typeof(AssembleVehicleEvent),
                    orderId);
                await PublishAssembleVehicleEvent(orderId, request.OrderItems);
            }
            else
            {
                logger.LogInformation("Publishing {ShortageEvent} for Order {ID}", typeof(ShortageEvent),
                    orderId);
                await PublishShortageEvent(shortageItems);
            }

            logger.LogInformation("Adding order in storage. Order: {order}", request);
            await AddOrder(orderId, request);

            return new CommandResponse()
            {
                OrderId = Guid.NewGuid()
            };
        }
        catch (Exception ex)
        {
            logger.LogError("Error handling Add Order Command: {message}", ex.Message);
            throw;
        }
    }


    #region Private methods

    private List<ShortageItem> GetShortageItems(IEnumerable<Domain.Entities.OrderItem> requestOrderItems,
        List<StockItemDto> responseDto)
    {
        var shortageItems = new List<ShortageItem>();

        foreach (var orderItem in requestOrderItems)
        {
            var stockItem =
                responseDto.FirstOrDefault(item => item.ProductId == orderItem.ProductId.ToString());
            if (stockItem != null && stockItem.AvailableQuantity >= orderItem.Quantity) continue;

            logger.LogInformation("Shortage detected for product ID: {ProductId}", orderItem.ProductId);

            shortageItems.Add(new ShortageItem
            {
                ProductId = orderItem.ProductId,
                RequiredQuantity = orderItem.Quantity - stockItem!.AvailableQuantity,
                Type = stockItem.Type
            });
        }

        return shortageItems;
    }

    private async Task PublishAssembleVehicleEvent(Guid orderId,
        IEnumerable<Domain.Entities.OrderItem> requestOrderItems)
    {
        var assembleVehicleEvent = new AssembleVehicleEvent()
        {
            OrderId = orderId,
            OrderItems = mapper.Map<IEnumerable<OrderItem>>(requestOrderItems)
        };

        await messageService.PublishEvent(assembleVehicleEvent);
    }

    private async Task PublishShortageEvent(List<ShortageItem> shortageItems)
    {
        var shortageEvent = new ShortageEvent
        {
            ShortageItems = shortageItems
        };

        await messageService.PublishEvent(shortageEvent);
    }

    private async Task AddOrder(Guid orderId, Command request)
    {
        Order orderToAdd = mapper.Map<Order>(request);
        orderToAdd.Id = orderId;

        await orderRepository.AddAsync(orderToAdd);
    }

    #endregion
}