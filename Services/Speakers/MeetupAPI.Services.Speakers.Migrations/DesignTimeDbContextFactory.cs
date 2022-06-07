using MeetupAPI.Services.Speakers.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MeetupAPI.Services.Speakers.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SpeakersDbContext>
{
    public SpeakersDbContext CreateDbContext(params string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<SpeakersDbContext>();
        optionsBuilder.UseNpgsql(
            config.GetConnectionString("SpeakersDb"),
            builder => builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.GetName().Name));

        return new SpeakersDbContext(optionsBuilder.Options);
    }
}
