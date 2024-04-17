using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderService.ApplicationService.Interfaces;
using OrderService.Domain;

namespace OrderService.ApplicationService.CQRS.Commands.AddOrderCommand;

public class CommandHandler(IOrderService orderService, IMapper mapper, ILogger<CommandHandler> logger) : IRequestHandler<Command, CommandResponse>
{
    public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            //Check availability
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