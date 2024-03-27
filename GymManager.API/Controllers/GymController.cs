using GymManager.Application.Commands.CreateGym;
using GymManager.Application.Queries.SearchGymByName;
using GymManager.Application.Queries.SearchNearbyGyms;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.API.Controllers;

[Route("api/gyms")]
[ApiController]
[Authorize]
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

    [HttpGet("nearby")]
    public async Task<IActionResult> SearchNearby(decimal latitude, decimal longitude)
    {
        var searchNearbyGymsQuery = new SearchNearbyGymsQuery(latitude, longitude);
        var gymsViewModel = await _mediator.Send(searchNearbyGymsQuery);

        return Ok(gymsViewModel);
    }
}
