using GymManager.Application.Commands.AuthenticateUser;
using GymManager.Application.Commands.RegisterUser;
using GymManager.Application.Queries.GetUserProfile;

using MediatR;

using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("/authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateUserCommand authenticateUserCommand)
    {
        var loginViewModel = await _mediator.Send(authenticateUserCommand);

        return Ok(loginViewModel);
    }

    [Authorize]
    [HttpGet("/profile/{id:guid}")]
    public async Task<IActionResult> GetProfile(Guid id)
    {
        var getUserProfileQuery = new GetUserProfileQuery(id);

        var userProfileViewModel = await _mediator.Send(getUserProfileQuery);

        return Ok(userProfileViewModel);
    }
}
