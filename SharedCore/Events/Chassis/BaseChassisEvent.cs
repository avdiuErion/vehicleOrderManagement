namespace SharedCore.Events.Chassis;

public abstract class BaseChassisEvent
{
    public Guid ChassisOrderId { get; set; }
    public Guid OrderId { get; set; }
}