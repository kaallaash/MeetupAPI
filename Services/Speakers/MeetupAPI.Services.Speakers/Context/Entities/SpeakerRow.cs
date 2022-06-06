namespace MeetupAPI.Services.Speakers.Context.Entities;

public class SpeakerRow
{
    public SpeakerRow(
        string id,
        string name,
        string lastName,
        string phone,
        DateTimeOffset dateCreated,
        DateTimeOffset dateUpdated)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Phone = phone;
        DateCreated = dateCreated;
        DateUpdated = dateUpdated;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
}
