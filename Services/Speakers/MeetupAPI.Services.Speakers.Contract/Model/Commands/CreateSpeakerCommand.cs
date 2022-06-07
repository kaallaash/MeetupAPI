namespace MeetupAPI.Services.Speakers.Contract.Model.Commands;

public record CreateSpeakerCommand(
    string Name,
    string LastName,
    string Phone);