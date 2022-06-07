using MeetupAPI.Shared.Core.Database;

using MeetupAPI.Services.Meetups.Context;

namespace MeetupAPI.Services.Meetups.Migrations;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var cancellationToken = new CancellationToken();
        var service = new DatabaseMigrationService<MeetupsDbContext>();

        await service
            .Migrate(
                args,
                new DesignTimeDbContextFactory(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}