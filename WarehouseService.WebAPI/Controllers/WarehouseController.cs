using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCore.BaseClasses;
using GetAllStockItemsQuery = WarehouseService.ApplicationService.CQRS.Queries.GetAllStockItemsQuery;

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
}