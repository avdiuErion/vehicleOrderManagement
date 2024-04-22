namespace SharedCore.Events.Order;

public class AssembleVehicleEvent
{
    public Guid OrderId { get; set; }

    public IEnumerable<OrderItem> OrderItems { get; set; }
}

public class OrderItem
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}