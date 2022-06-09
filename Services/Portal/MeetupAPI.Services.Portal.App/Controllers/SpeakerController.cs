//using MeetupAPI.Services.Speakers.Contract;
//using MeetupAPI.Services.Speakers.Contract.Model;
//using MeetupAPI.Services.Speakers.Contract.Model.Commands;

//using MeetupAPI.Shared.Services.Api;

//using Microsoft.AspNetCore.Mvc;

//namespace MeetupAPI.Services.Portal.App.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class SpeakerController : Controller
//{
//    private readonly ISpeakerService _speakerService;

//    public SpeakerController(
//        ISpeakerService speakerService)
//    {
//        _speakerService = speakerService;
//    }

//    [HttpGet("{id}")]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
//    public async Task<ActionResult<Speaker>> Get(
//    [FromRoute] string id,
//    CancellationToken cancellationToken = default)
//    {
//        var result = await _speakerService
//            .Get(id, cancellationToken)
//            .WithActionResult()
//            .ConfigureAwait(false);

//        return result;
//    }

//    [HttpPost]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
//    public async Task<ActionResult<Speaker>> Create(
//      [FromBody] CreateSpeakerCommand command,
//      CancellationToken cancellationToken = default)
//    {
//        var result = await _speakerService
//            .Create(command, cancellationToken)
//            .WithActionResult()
//            .ConfigureAwait(false);

//        return result;
//    }

//    ////[HttpPut]
//    ////[ProducesResponseType(StatusCodes.Status200OK)]
//    ////[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
//    ////public async Task<ActionResult<Speaker>> Update(
//    ////  [FromBody] UpdateSpeakerCommand command,
//    ////  CancellationToken cancellationToken = default)
//    ////{
//    ////    var result = await _speakerService
//    ////        .Update(command, cancellationToken)
//    ////        .WithActionResult()
//    ////        .ConfigureAwait(false);

//    ////    return result;
//    ////}

//    ////[HttpDelete]
//    ////[ProducesResponseType(StatusCodes.Status200OK)]
//    ////[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
//    ////public async Task<ActionResult<Speaker>> Delete(
//    ////  [FromBody] string id,
//    ////  CancellationToken cancellationToken = default)
//    ////{
//    ////     await _speakerService
//    ////        .Delete(id, cancellationToken)
//    ////        .WithActionResult()
//    ////        .ConfigureAwait(false);

//    ////    return Ok();
//    ////}
//}
