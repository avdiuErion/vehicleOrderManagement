namespace SharedCore.Events.OptionPacks;

public abstract class OptionPacksBaseEvent
{
    public Guid OptionPacksOrderId { get; set; }
    public Guid OrderId { get; set; }
}