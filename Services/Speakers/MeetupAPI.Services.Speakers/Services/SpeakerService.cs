using MeetupAPI.Services.Speakers.Contract;
using MeetupAPI.Services.Speakers.Contract.Model;
using MeetupAPI.Services.Speakers.Context.Entities;
using MeetupAPI.Services.Speakers.Context;
using Microsoft.EntityFrameworkCore;
using MeetupAPI.Services.Speakers.Contract.Model.Commands;
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

        public async Task<Speaker> Update(
            UpdateSpeakerCommand command,
            CancellationToken cancellationToken = default)
        {
            var row = await _dbContext.Speakers
               .AsNoTracking()
               .SingleOrDefaultAsync(
                   r => r.Id == command.Id,
                   cancellationToken)
               .ConfigureAwait(false);

            if (row == null)
            {
                throw new InvalidOperationException($"The user by id = {command.Id} is not found");
            }

            row.Name = command.Name;
            row.LastName = command.LastName;
            row.Phone = command.Phone;
            row.DateUpdated = DateTimeOffset.UtcNow;

            _dbContext.Speakers.Update(row);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return MapToDto(row);
        }

        public async Task Delete(
            string id,
            CancellationToken cancellationToken = default)
        {
            var row = await _dbContext.Speakers
                   .AsNoTracking()
                   .SingleOrDefaultAsync(
                       t => t.Id == id,
                       cancellationToken)
                   .ConfigureAwait(false);

            if (row != null)
            {
                _dbContext.Speakers.Remove(row);

                await _dbContext
                    .SaveChangesAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
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
