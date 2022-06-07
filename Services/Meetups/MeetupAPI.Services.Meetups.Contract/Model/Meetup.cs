namespace MeetupAPI.Services.Meetups.Contract.Model;

public record Meetup(
    string Id,
    string Title,
    string Description,
    string SpeakerId,
    DateTimeOffset Date);