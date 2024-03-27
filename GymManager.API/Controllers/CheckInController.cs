using GymManager.API.Extensions;
using GymManager.Application.Commands.CreateCheckIn;
using GymManager.Application.Queries.GetMetricsByUser;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.API.Controllers;

[Route("api/check-ins")]
[Authorize]
[ApiController]
public class CheckInController : ControllerBase
{
    private readonly IMediator _mediator;

    public CheckInController(IMediator mediator)
        => _mediator = mediator;


    [HttpGet("metrics")]
    public async Task<IActionResult> GetUserMetrics()
    {

        var getMetricsByUserQuery = new GetMetricsByUserQuery(User.GetId());

        var userMetricsViewModel = await _mediator.Send(getMetricsByUserQuery);

        return Ok(userMetricsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCheckIn(CreateCheckInCommand createCheckInCommand)
    {
        await _mediator.Send(createCheckInCommand);
        return Created();
    }
}
