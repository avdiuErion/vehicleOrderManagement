using MediatR;
using SharedCore.Interfaces;

namespace WarehouseService.ApplicationService.CQRS.Commands.AddVehicleComponentCommand;

public class CommandHandler(IMessageService messageService) : IRequestHandler<Command, CommandResponse>
{
    public Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}