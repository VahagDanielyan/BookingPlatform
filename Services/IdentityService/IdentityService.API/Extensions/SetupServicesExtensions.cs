using IdentityService.Application;
using IdentityService.Infrastructure;
using IdentityService.Persistence;

namespace IdentityService.API.Extensions;

public static class SetupServicesExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddPersistence()
            .AddApi();

        return builder;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            var config = app.Configuration;

            bool swaggerEnabled = config.GetValue<bool>("SwaggerSettings:Enabled");

            if (swaggerEnabled)
            {
                string title = config.GetRequiredSection("SwaggerSettings:Title").Value ??
                               throw new InvalidOperationException("SwaggerSettings:Title is null");
                string endpoint = config.GetRequiredSection("SwaggerSettings:Endpoint").Value ??
                                  throw new InvalidOperationException("SwaggerSettings:Endpoint is null");
                string routePrefix = config.GetRequiredSection("SwaggerSettings:RoutePrefix").Value ??
                                     throw new InvalidOperationException("SwaggerSettings:RoutePrefix is null");

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(endpoint, title);
                    c.RoutePrefix = routePrefix;
                });
            }
        }

        app.MapControllers();

        return app;
    }
}