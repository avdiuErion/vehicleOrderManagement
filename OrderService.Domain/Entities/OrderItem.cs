using SharedCore.BaseClasses;

namespace OrderService.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}