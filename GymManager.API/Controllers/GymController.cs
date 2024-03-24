using GymManager.Application.Commands.CreateGym;
using GymManager.Application.Queries.SearchGymByName;
using GymManager.Core.Enums;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.API.Controllers;

[Route("api/gyms")]
[ApiController]
public class GymController : ControllerBase
{
    private readonly IMediator _mediator;

    public GymController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateGym(CreateGymCommand createGymCommand)
    {
        await _mediator.Send(createGymCommand);

        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> SearchGym(string name)
    {
        var searchGymByNameQuery = new SearchGymByNameQuery(name);

        var gymsViewModel = await _mediator.Send(searchGymByNameQuery);

        return Ok(gymsViewModel);
    }
}
