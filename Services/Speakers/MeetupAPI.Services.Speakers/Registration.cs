using MeetupAPI.Services.Speakers.Context;
using MeetupAPI.Services.Speakers.Contract;
using MeetupAPI.Services.Speakers.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Services.Speakers;

public static class Registration
{
    public static IServiceCollection AddSpeakers(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<SpeakersDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("SpeakersDb")));

        services.AddScoped<ISpeakerService, SpeakerService>();

        return services;
    }
}
