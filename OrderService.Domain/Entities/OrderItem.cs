using System.ComponentModel.DataAnnotations.Schema;
using SharedCore.BaseClasses;

namespace OrderService.Domain;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}