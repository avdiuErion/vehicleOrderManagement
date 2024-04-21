using MediatR;
using Microsoft.Extensions.Logging;
using SharedCore.Clients.Interfaces;
using SharedCore.Dtos;
using SharedCore.Events;
using SharedCore.Interfaces;

namespace OrderService.ApplicationService.CQRS.Commands.AddOrderCommand;

public class CommandHandler(ILogger<CommandHandler> logger, IWarehouseClient warehouseClient, IMessageService messageService) : IRequestHandler<Command, CommandResponse>
{
    public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            InventoryResponseDto? responseDto = await warehouseClient.GetStockItems();
            var shortageItems = new List<ShortageItem>();

            if (responseDto != null && responseDto!.StockItems!.Any())
            {
                foreach (var orderItem in request.OrderItems)
                {
                    var stockItem = responseDto!.StockItems!.FirstOrDefault(item => item.ProductId == orderItem.ProductId.ToString());
                    if (stockItem != null && stockItem.AvailableQuantity >= orderItem.Quantity) continue;
                
                    // Shortage detected for this order item
                    logger.LogInformation("Shortage detected for product ID: {ProductId}", orderItem.ProductId);
            
                    shortageItems.Add(new ShortageItem()
                    {
                        ProductId = orderItem.ProductId,
                        RequiredQuantity = orderItem.Quantity - stockItem!.AvailableQuantity
                    });
                }
            }

            if (!shortageItems.Any())
            {
                var shortageEvent = new ShortageEvent
                {
                    ShortageItems = shortageItems
                };

                await messageService.PublishEvent(shortageEvent);
            }
            else
            {
                // Publish ShortageEvent
                var shortageEvent = new ShortageEvent
                {
                    ShortageItems = shortageItems
                };

                await messageService.PublishEvent(shortageEvent);
            }
            //If any missing, schedule for production
                //Send message to specific service
                    //Specific service produces component, informs assemblyservice/customer
                        //AssemblyService assembles vehicle, sends to warehouse
                            //Warehouse informs customer
            //If all available, assemble vehicle
                //AssemblyService assembles vehicle, sends to warehouse
                    //Warehouse informs customer
                    
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
}