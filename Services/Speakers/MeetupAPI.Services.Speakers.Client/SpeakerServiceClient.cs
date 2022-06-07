using MeetupAPI.Services.Speakers.Contract;

namespace MeetupAPI.Services.Speakers.Client;

public partial class SpeakerServiceClient : ISpeakerService
{
    public async Task<Speaker> Get(
        string id,
        CancellationToken cancellationToken = default)
    {
        return await GetAsync(
            id,
            cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Speaker> Create(
        CreateSpeakerCommand command,
        CancellationToken cancellationToken = default)
    {
        return await CreateAsync(
            command,
            cancellationToken)
            .ConfigureAwait(false);
    }
}
