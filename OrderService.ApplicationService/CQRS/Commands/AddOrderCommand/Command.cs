using MediatR;
using OrderService.Domain;
using OrderService.Domain.Entities;

namespace OrderService.ApplicationService.CQRS.Commands.AddOrderCommand;

public class Command : IRequest<CommandResponse>
{
    public Guid CustomerId { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}