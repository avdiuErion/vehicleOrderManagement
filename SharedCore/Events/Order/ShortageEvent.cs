using SharedCore.Enums;

namespace SharedCore.Events.Order;

public class ShortageEvent
{
    public Guid OrderId { get; set; }
    public IEnumerable<ShortageItem> ShortageItems { get; set; }
}

public class ShortageItem
{
    public Guid ProductId { get; set; }
    public int RequiredQuantity { get; set; }
    public ProductType Type { get; set; }
}