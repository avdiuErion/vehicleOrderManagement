using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCore.BaseClasses;
using GetAllQuery = EngineService.ApplicationService.CQRS.Queries.GetAll;

namespace EngineService.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EngineController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<GetAllQuery.QueryResponse>>> GetAll()
    {
        List<GetAllQuery.QueryResponse> response = await Mediator.Send(new GetAllQuery.Query());

        return Ok(response);
    }
}