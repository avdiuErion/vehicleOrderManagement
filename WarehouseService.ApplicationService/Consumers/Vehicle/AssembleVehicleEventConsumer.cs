using AutoMapper;
using MassTransit;
using SharedCore.Events.Order;
using Warehouse.DataAccess.Interfaces;
using Warehouse.Domain.Entities;

namespace WarehouseService.ApplicationService.Consumers.Vehicle;

public class AssembleVehicleEventConsumer(IVehicleRepository vehicleRepository, IMapper mapper) : IConsumer<AssembleVehicleEvent>
{
    public async Task Consume(ConsumeContext<AssembleVehicleEvent> context)
    {
        Warehouse.Domain.Entities.Vehicle vehicle = new Warehouse.Domain.Entities.Vehicle()
        {
            Id = Guid.NewGuid(),
            OrderId = context.Message.OrderId,
            Description = "Vehicle",
            IsAssembled = false,
            InventoryItems = mapper.Map<List<InventoryItem>>(context.Message.OrderItems)
        };

        await vehicleRepository.AddAsync(vehicle);
    }
}