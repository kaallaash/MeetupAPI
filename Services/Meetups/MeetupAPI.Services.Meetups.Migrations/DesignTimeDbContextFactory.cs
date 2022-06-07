using MeetupAPI.Services.Meetups.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MeetupAPI.Services.Meetups.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MeetupsDbContext>
{
    public MeetupsDbContext CreateDbContext(params string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MeetupsDbContext>();
        optionsBuilder.UseNpgsql(
            config.GetConnectionString("MeetupsDb"),
            builder => builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.GetName().Name));

        return new MeetupsDbContext(optionsBuilder.Options);
    }
}