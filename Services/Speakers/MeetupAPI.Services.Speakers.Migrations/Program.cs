using MeetupAPI.Shared.Core.Database;

using MeetupAPI.Services.Speakers.Context;

namespace MeetupAPI.Services.Speakers.Migrations;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var cancellationToken = new CancellationToken();
        var service = new DatabaseMigrationService<SpeakersDbContext>();

        await service
            .Migrate(
                args,
                new DesignTimeDbContextFactory(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}