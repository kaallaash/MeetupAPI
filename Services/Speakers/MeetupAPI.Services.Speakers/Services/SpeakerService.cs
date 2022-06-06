using MeetupAPI.Services.Speakers.Contract;
using MeetupAPI.Services.Speakers.Contract.Model;
using MeetupAPI.Services.Speakers.Context.Entities;
using MeetupAPI.Services.Speakers.Context;
using Microsoft.EntityFrameworkCore;
using MeetupAPI.Services.Speakers.Contract.Model.Command;
using NUlid;

namespace MeetupAPI.Services.Speakers.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly SpeakersDbContext _dbContext;

        public SpeakerService(
            SpeakersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Speaker> Get(
        string id,
        CancellationToken cancellationToken = default)
        {
            var row = await _dbContext.Speakers
                .AsNoTracking()
                .SingleOrDefaultAsync(
                    r => r.Id == id,
                    cancellationToken)
                .ConfigureAwait(false);

            if (row == null)
            {
                throw new InvalidOperationException($"The user by id = {id} is not found");
            }

            return MapToDto(row);
        }

        public async Task<Speaker> Create(
            CreateSpeakerCommand command,
            CancellationToken cancellationToken = default)
        {
            var row = new SpeakerRow(
                Ulid.NewUlid().ToString(),
                command.Name,
                command.LastName,
                command.Phone,
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow);

            await _dbContext.Speakers
                .AddAsync(row, cancellationToken)
                .ConfigureAwait(false);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return MapToDto(row);
        }

        private static Speaker MapToDto(SpeakerRow row)
        {
            return new Speaker(
                row.Id,
                row.Name,
                row.LastName,
                row.Phone);
        }
    }
}
