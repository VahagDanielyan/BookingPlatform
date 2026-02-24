using BookingService.API.Configurations;
using BookingService.Application;
using BookingService.Infrastructure;
using BookingService.Persistence;
using Microsoft.Extensions.Options;

namespace BookingService.API.Extensions;

public static class SetupServicesExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddPersistence()
            .AddApi(builder.Configuration);

        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            var swaggerSettings = app.Services
                .GetRequiredService<IOptions<SwaggerSettings>>()
                .Value;
            
            if (swaggerSettings.IsEnabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(swaggerSettings.Endpoint, swaggerSettings.Title);
                    c.RoutePrefix = swaggerSettings.RoutePrefix;
                });
            }
        }

        app.MapControllers();

        return app;
    }
}