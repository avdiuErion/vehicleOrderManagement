using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCore.BaseClasses;
using AddOrderCommand = OrderService.ApplicationService.CQRS.Commands.AddOrderCommand.Command;

namespace OrderService.WebAPI.Controllers;

public class OrderController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("PlaceOrder")]
    public async Task<ActionResult> PaginateCommunityDocuments()
    {
        await Mediator.Send(new AddOrderCommand());

        return Ok();

    }
}