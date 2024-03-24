using GymManager.Application.Commands.RegisterUser;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GymManager.API.Controllers;

[Route("/api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
    {
        await _mediator.Send(registerUserCommand);

        return Created();
    }

}
