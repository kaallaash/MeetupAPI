namespace MeetupAPI.Services.Meetups.Context.Entities;

public class MeetupRow
{
    public MeetupRow(
    string id,
    string title,
    string description,
    string speakerId,
    DateTimeOffset date,
    DateTimeOffset dateCreated,    
    DateTimeOffset dateUpdated)
    {
        Id = id;
        Title = title;
        Description = description;
        SpeakerId = speakerId;
        Date = date;
        DateCreated = dateCreated;
        DateUpdated = dateUpdated;
    }

    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string SpeakerId { get; set; }
    public DateTimeOffset Date { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
}
