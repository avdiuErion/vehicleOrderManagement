using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCore.BaseClasses;
using AddOrderCommand = OrderService.ApplicationService.CQRS.Commands.AddOrderCommand;

namespace OrderService.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("PlaceOrder")]
    public async Task<ActionResult<AddOrderCommand.CommandResponse>> PlaceOrder([FromBody] AddOrderCommand.Command command)
    {
        AddOrderCommand.CommandResponse response = await Mediator.Send(command);

        return Ok(response);
    }
}