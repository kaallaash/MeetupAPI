﻿using System.Text.Json.Serialization;

using NJsonSchema.Generation;

namespace MeetupAPI.Services.Meetups.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMeetups(Configuration);

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
}
