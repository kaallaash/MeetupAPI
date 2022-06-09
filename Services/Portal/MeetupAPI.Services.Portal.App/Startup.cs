using System.Text.Json.Serialization;

using MeetupAPI.Services.Meetups.Client;
using MeetupAPI.Services.Meetups.Contract;
using MeetupAPI.Services.Speakers.Client;
using MeetupAPI.Services.Speakers.Contract;

using MeetupAPI.Shared.Services;

using NJsonSchema.Generation;

namespace MeetupAPI.Services.Portal.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        AddServiceClients(services);

        services
            .AddControllers()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.AllowTrailingCommas = true;
                });

        services.AddOpenApiDocument(
            settings =>
            {
                settings.DocumentName = "openapi";
                settings.SchemaGenerator.Settings.DefaultReferenceTypeNullHandling =
                ReferenceTypeNullHandling.NotNull;
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.UseOpenApi(settings => settings.Path = "/api/swagger/{documentName}/swagger.json");
        app.UseSwaggerUi3(
            settings =>
            {
                settings.Path = "/api/swagger";
                settings.DocumentPath = "/api/swagger/{documentName}/swagger.json";
            });
        app.UseReDoc(
            settings =>
            {
                settings.Path = "/api/redoc";
                settings.DocumentPath = "/api/swagger/{documentName}/swagger.json";
            });
    }

    private static void AddServiceClients(IServiceCollection services)
    {
        services.AddServiceClient<ISpeakerService, SpeakerServiceClient>("Speakers");
        services.AddServiceClient<IMeetupService, MeetupServiceClient>("Meetups");
    }
}