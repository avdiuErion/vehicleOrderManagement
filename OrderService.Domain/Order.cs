using OrderService.ApplicationService.Enums;
using SharedCore.BaseClasses;

namespace OrderService.Domain;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public List<OrderLine> OrderLines { get; set; }
    public OrderStatus Status { get; set; }
    
    public Customer Customer { get; set; }


}