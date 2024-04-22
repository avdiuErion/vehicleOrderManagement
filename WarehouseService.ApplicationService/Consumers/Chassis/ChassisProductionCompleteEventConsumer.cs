using MassTransit;
using SharedCore.Events.Chassis;

namespace WarehouseService.ApplicationService.Consumers.Chassis;

public class ChassisProductionCompleteEventConsumer : IConsumer<ChassisProductionCompleteEvent>
{
    public Task Consume(ConsumeContext<ChassisProductionCompleteEvent> context)
    {
        throw new NotImplementedException();
    }
}