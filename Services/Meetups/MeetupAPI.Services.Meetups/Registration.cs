using MeetupAPI.Services.Meetups.Context;
using MeetupAPI.Services.Meetups.Contract;
using MeetupAPI.Services.Meetups.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Services.Meetups;

public static class Registration
{
    public static IServiceCollection AddMeetups(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<MeetupsDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("MeetupsDb")));

        services.AddScoped<IMeetupService, MeetupService>();

        return services;
    }
}
