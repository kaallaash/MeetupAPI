using MeetupAPI.Shared.Services.Api;

using MeetupAPI.Services.Meetups.Contract;
using MeetupAPI.Services.Meetups.Contract.Model;
using MeetupAPI.Services.Meetups.Contract.Model.Commands;

using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Services.Meetups.App.Controllers;

[ApiController]
[Route("[controller]")]
public class MeetupController : Controller
{
    private readonly IMeetupService _meetupService;

    public MeetupController(
        IMeetupService meetupService)
    {
        _meetupService = meetupService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Meetup>> Get(
    [FromRoute] string id,
    CancellationToken cancellationToken = default)
    {
        var result = await _meetupService
            .Get(id, cancellationToken)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Meetup>> Create(
      [FromBody] CreateMeetupCommand command,
      CancellationToken cancellationToken = default)
    {
        var result = await _meetupService
            .Create(command, cancellationToken)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Meetup>> Update(
      [FromBody] UpdateMeetupCommand command,
      CancellationToken cancellationToken = default)
    {
        var result = await _meetupService
            .Update(command, cancellationToken)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(
        [FromRoute] string id,
        CancellationToken cancellationToken = default)
    {
        await _meetupService
            .Delete(id, cancellationToken)
            .ConfigureAwait(false);

        return Ok();
    }
}
