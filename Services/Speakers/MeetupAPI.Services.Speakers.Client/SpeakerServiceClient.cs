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

    public async Task<Speaker> Update(
      UpdateSpeakerCommand command,
      CancellationToken cancellationToken = default)
    {
        return await UpdateAsync(
            command,
            cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Delete(
        string id,
        CancellationToken cancellationToken = default)
    {
        await DeleteAsync(id,cancellationToken)
            .ConfigureAwait(false);
    }
}
