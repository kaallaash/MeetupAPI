namespace MeetupAPI.Services.Speakers.Contract.Model;

public record Speaker(
    string Id,
    string Name,
    string LastName,
    string Phone);