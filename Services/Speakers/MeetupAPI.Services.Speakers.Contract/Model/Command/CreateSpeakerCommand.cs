namespace MeetupAPI.Services.Speakers.Contract.Model.Command;

public record CreateSpeakerCommand(
    string Name,
    string LastName,
    string Phone);