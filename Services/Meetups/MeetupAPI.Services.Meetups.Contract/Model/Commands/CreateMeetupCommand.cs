namespace MeetupAPI.Services.Meetups.Contract.Model.Commands;

public record CreateMeetupCommand(
    string Title,
    string Description,
    string SpeakerId,
    DateTimeOffset Date);