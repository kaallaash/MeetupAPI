namespace MeetupAPI.Services.Meetups.Contract.Model.Commands;

public record UpdateMeetupCommand(
    string Id,
    string Title,
    string Description,
    string SpeakerId,
    DateTimeOffset Date);