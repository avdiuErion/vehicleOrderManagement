using MediatR;

namespace WarehouseService.ApplicationService.CQRS.Commands.VehicleAssembledCommand;

public class Command : IRequest<CommandResponse>
{
    public Guid VehicleId { get; set; }
}