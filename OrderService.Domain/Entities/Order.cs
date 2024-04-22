using OrderService.Domain.Entities;
using OrderService.Domain.Enums;
using SharedCore.BaseClasses;

namespace OrderService.Domain;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public OrderStatus Status { get; set; }
}