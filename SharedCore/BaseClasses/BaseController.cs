using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SharedCore.BaseClasses;

public class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}