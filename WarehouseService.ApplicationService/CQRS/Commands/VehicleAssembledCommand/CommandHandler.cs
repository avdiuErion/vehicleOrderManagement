using MediatR;
using SharedCore.Events.Warehouse;
using SharedCore.Interfaces;
using Warehouse.DataAccess.Interfaces;
using Warehouse.Domain.Entities;

namespace WarehouseService.ApplicationService.CQRS.Commands.VehicleAssembledCommand;

public class CommandHandler(IVehicleRepository vehicleRepository, IMessageService messageService) : IRequestHandler<Command, CommandResponse>
{
    public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        Vehicle vehicle = await vehicleRepository.FirstOrDefaultAsync(x => x!.Id == request.VehicleId);
        vehicle.IsAssembled = true;

        await vehicleRepository.UpdateAsync(vehicle);

        if (vehicle.OrderId != null)
        {
            await messageService.PublishEvent(new OrderCompletedEvent()
            {
                OrderId = vehicle.OrderId!.Value
            });
        }

        return new CommandResponse()
        {
            Success = true
        };
    }
}