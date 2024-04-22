using MediatR;

namespace WarehouseService.ApplicationService.CQRS.Commands.AssembleVehicleCommand;

public class CommandHandler : IRequestHandler<Command, CommandResponse>
{
    public Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}