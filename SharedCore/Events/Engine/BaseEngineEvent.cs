namespace SharedCore.Events.Engine;

public abstract class BaseEngineEvent 
{
    public Guid EngineOrderId { get; set; }
    public Guid OrderId { get; set; }
}