namespace MeetupAPI.Services.Speakers.Contract.Model.Commands;

public record UpdateSpeakerCommand(
    string Id,
    string Name,
    string LastName,
    string Phone);