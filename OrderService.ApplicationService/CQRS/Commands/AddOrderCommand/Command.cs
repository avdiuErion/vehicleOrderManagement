using MediatR;
using OrderService.Domain;

namespace OrderService.ApplicationService.CQRS.Commands.AddOrderCommand;

public class Command : IRequest<CommandResponse>
{
    public string CustomerName { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}