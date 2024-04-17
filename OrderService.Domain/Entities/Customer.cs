using SharedCore.BaseClasses;

namespace OrderService.Domain;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
}