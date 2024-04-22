using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCore.BaseClasses;
using GetAllQuery = OptionPacksService.ApplicationService.CQRS.Queries.GetAll;


namespace OptionPacksService.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionPacksController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<GetAllQuery.QueryResponse>>> GetAll()
    {
        List<GetAllQuery.QueryResponse> response = await Mediator.Send(new GetAllQuery.Query());

        return Ok(response);
    }
}