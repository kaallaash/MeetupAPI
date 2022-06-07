using MeetupAPI.Services.Meetups.Contract.Model;
using MeetupAPI.Services.Meetups.Contract.Model.Commands;

namespace MeetupAPI.Services.Meetups.Contract
{
    public interface IMeetupService
    {
        Task<Meetup> Create(
            CreateMeetupCommand command,
            CancellationToken cancellationToken = default);

        Task<Meetup> Get(
            string id,
            CancellationToken cancellationToken = default);

        Task<Meetup> Update(
            UpdateMeetupCommand command,
            CancellationToken cancellationToken = default);

        Task<Meetup> Delete(
            string id,
            CancellationToken cancellationToken = default);
    }
}