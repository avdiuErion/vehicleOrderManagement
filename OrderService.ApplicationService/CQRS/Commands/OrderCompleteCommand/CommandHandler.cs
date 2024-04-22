using MediatR;
using Microsoft.Extensions.Logging;
using OrderService.DataAccess.Interfaces;
using OrderService.Domain;
using OrderService.Domain.Enums;
using SharedCore.Events.Order;
using SharedCore.Interfaces;

namespace OrderService.ApplicationService.CQRS.Commands.OrderCompleteCommand;

public class CommandHandler(IOrderRepository orderRepository, ILogger<CommandHandler> logger, IMessageService messageService) : IRequestHandler<Command, CommandResponse>
{
    public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            Order? order = await orderRepository.FirstOrDefaultAsync(x => x!.Id == request.OrderId);

            order.Status = OrderStatus.Completed;

            await orderRepository.UpdateAsync(order);

            await messageService.PublishEvent(new OrderReadyEvent()
            {
                OrderId = request.OrderId
            });

            return new CommandResponse()
            {
                OrderId = request.OrderId
            };
        }
        catch (Exception ex)
        {
            logger.LogError("Error completing order {ID}: {error}", request.OrderId, ex.Message);
            throw;
        }
    }
}