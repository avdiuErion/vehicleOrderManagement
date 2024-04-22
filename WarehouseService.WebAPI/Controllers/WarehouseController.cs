using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCore.BaseClasses;
using GetAllStockItemsQuery = WarehouseService.ApplicationService.CQRS.Queries.GetAllStockItemsQuery;
using VehicleAssembledCommand = WarehouseService.ApplicationService.CQRS.Commands.VehicleAssembledCommand;

namespace Warehouse.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WarehouseController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<GetAllStockItemsQuery.QueryResponse>>> GetAll()
    {
        List<GetAllStockItemsQuery.QueryResponse> response = await Mediator.Send(new GetAllStockItemsQuery.Query());

        return Ok(response);
    }
    
    [HttpPost("VehicleAssembled/{vehicleId}")]
    public async Task<ActionResult<VehicleAssembledCommand.CommandResponse>> Vehicle(Guid vehicleId)
    {
        VehicleAssembledCommand.CommandResponse response = await Mediator.Send(new VehicleAssembledCommand.Command()
        {
            VehicleId = vehicleId
        });

        return Ok(response);
    }
}