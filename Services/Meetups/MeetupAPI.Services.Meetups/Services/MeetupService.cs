using MeetupAPI.Services.Meetups.Context;
using MeetupAPI.Services.Meetups.Context.Entities;
using MeetupAPI.Services.Meetups.Contract;
using MeetupAPI.Services.Meetups.Contract.Model;
using MeetupAPI.Services.Meetups.Contract.Model.Commands;

using Microsoft.EntityFrameworkCore;

using NUlid;

namespace MeetupAPI.Services.Meetups.Services;

public class MeetupService : IMeetupService
{
    private readonly MeetupsDbContext _dbContext;

    public MeetupService(
        MeetupsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Meetup> Get(
    string id,
    CancellationToken cancellationToken = default)
    {
        var row = await GetRow(id, cancellationToken)
            .ConfigureAwait(false);

        return MapToDto(row);
    }

    public async Task<Meetup> Create(
        CreateMeetupCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = new MeetupRow(
            Ulid.NewUlid().ToString(),
            command.Title,
            command.Description,
            command.SpeakerId,
            command.Date,
            DateTimeOffset.UtcNow,
            DateTimeOffset.UtcNow);

        await _dbContext.Meetups
            .AddAsync(row, cancellationToken)
            .ConfigureAwait(false);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return MapToDto(row);
    }

    public async Task<Meetup> Update(
        UpdateMeetupCommand command,
        CancellationToken cancellationToken = default)
    {
        var row = await GetRow(command.Id, cancellationToken)
            .ConfigureAwait(false);

        row.Title = command.Title;
        row.Description = command.Description;
        row.SpeakerId = command.SpeakerId;
        row.Date = command.Date;
        row.DateUpdated = DateTimeOffset.UtcNow;

        _dbContext.Meetups.Update(row);

        await _dbContext
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return MapToDto(row);
    }

    public async Task Delete(
        string id,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Meetups
               .AsNoTracking()
               .SingleOrDefaultAsync(
                   t => t.Id == id,
                   cancellationToken)
               .ConfigureAwait(false);

        if (row != null)
        {
            _dbContext.Meetups.Remove(row);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }

    private async Task<MeetupRow> GetRow(
        string id,
        CancellationToken cancellationToken = default)
    {
        var row = await _dbContext.Meetups
            .AsNoTracking()
            .SingleOrDefaultAsync(
                r => r.Id == id,
                cancellationToken)
            .ConfigureAwait(false);

        if (row == null)
        {
            throw new InvalidOperationException($"The user by id = {id} is not found");
        }

        return row;
    }

    private static Meetup MapToDto(MeetupRow row)
    {
        return new Meetup(
            row.Id,
            row.Title,
            row.Description,
            row.SpeakerId,
            row.Date);
    }
}
