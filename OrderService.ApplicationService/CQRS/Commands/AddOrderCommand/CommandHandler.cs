using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderService.ApplicationService.Interfaces;
using OrderService.Domain;
using SharedCore.Clients.Interfaces;
using SharedCore.Dtos;

namespace OrderService.ApplicationService.CQRS.Commands.AddOrderCommand;

public class CommandHandler(ILogger<CommandHandler> logger, IWarehouseClient warehouseClient) : IRequestHandler<Command, CommandResponse>
{
    public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            //Check availability
            InventoryResponseDto? responseDto = await warehouseClient.CheckForInventory(request.OrderItems);
            if (responseDto!.MissingItems!.Any())
            {
                //Send message to specific service
            }
            else
            {
                //assemble vehicle
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