using MeetupAPI.Services.Meetups.Contract;

namespace MeetupAPI.Services.Meetups.Client;

public partial class MeetupServiceClient : IMeetupService
{
    public async Task<Meetup> Get(
        string id,
        CancellationToken cancellationToken = default)
    {
        return await GetAsync(id, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Meetup> Create(
        CreateMeetupCommand command,
        CancellationToken cancellationToken = default)
    {
        return await CreateAsync(command, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Meetup> Update(
        UpdateMeetupCommand command,
        CancellationToken cancellationToken = default)
    {
        return await UpdateAsync(command, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Delete(
        string id,
        CancellationToken cancellationToken = default)
    {
        await DeleteAsync(id, cancellationToken)
            .ConfigureAwait(false);
    }
}
