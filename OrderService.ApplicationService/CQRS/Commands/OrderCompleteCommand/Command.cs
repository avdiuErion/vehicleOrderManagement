using MediatR;

namespace OrderService.ApplicationService.CQRS.Commands.OrderCompleteCommand;

public class Command : IRequest<CommandResponse>
{
    public Guid OrderId { get; set; }
}