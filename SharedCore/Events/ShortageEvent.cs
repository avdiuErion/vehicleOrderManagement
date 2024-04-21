namespace SharedCore.Events;

public class ShortageEvent
{
   public IEnumerable<ShortageItem> ShortageItems { get; set; }
}

public class ShortageItem
{
    public Guid ProductId { get; set; }
    public int RequiredQuantity { get; set; }
}