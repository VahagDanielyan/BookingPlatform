using IdentityService.API.Configurations;
using IdentityService.Application;
using IdentityService.Infrastructure;
using IdentityService.Persistence;
using IdentityService.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IdentityService.API.Extensions;

public static class SetupApplicationExtensions
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
            app.UseSwaggerIfEnabled();
            app.ApplyAutoMigrationIfEnabled();
        }

        app.MapControllers();

        return app;
    }

    private static void UseSwaggerIfEnabled(this WebApplication app)
    {
        var swaggerSettings = app.Services
            .GetRequiredService<IOptions<SwaggerSettings>>()
            .Value;

        if (!swaggerSettings.IsEnabled) return;

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(swaggerSettings.Endpoint, swaggerSettings.Title);
            c.RoutePrefix = swaggerSettings.RoutePrefix;
        });
    }

    private static void ApplyAutoMigrationIfEnabled(this WebApplication app)
    {
        var isAutoMigrationEnabled = app.Configuration.GetValue<bool>("IsAutoMigrationEnabled");

        if (!isAutoMigrationEnabled) return;

        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BpIdentityServiceDbContext>();

        db.Database.Migrate();
    }
}