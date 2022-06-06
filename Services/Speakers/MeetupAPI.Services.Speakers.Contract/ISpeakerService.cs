using MeetupAPI.Services.Speakers.Contract.Model;
using MeetupAPI.Services.Speakers.Contract.Model.Command;

namespace MeetupAPI.Services.Speakers.Contract;

public interface ISpeakerService
{
    Task<Speaker> Create(
        CreateSpeakerCommand command,
        CancellationToken cancellationToken = default);

    Task<Speaker> Get(
      string id,
      CancellationToken cancellationToken = default);
}
