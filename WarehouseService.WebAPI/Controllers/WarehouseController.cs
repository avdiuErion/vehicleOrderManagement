using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCore.BaseClasses;
using CheckInventoryQuery = WarehouseService.ApplicationService.CQRS.Queries.CheckInventoryQuery;

namespace Warehouse.WebAPI.Controllers;

public class WarehouseController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("CheckForInventory")]
    public async Task<ActionResult<CheckInventoryQuery.QueryResponse>> CheckForInventory([FromBody] CheckInventoryQuery.Query query)
    {
        CheckInventoryQuery.QueryResponse response = await mediator.Send(query);

        return Ok(response);
    }
}