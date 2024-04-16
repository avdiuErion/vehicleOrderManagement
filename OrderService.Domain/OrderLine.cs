using SharedCore.BaseClasses;

namespace OrderService.Domain;

public class OrderLine : BaseEntity
{
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    
    public Order Order { get; set; }
}