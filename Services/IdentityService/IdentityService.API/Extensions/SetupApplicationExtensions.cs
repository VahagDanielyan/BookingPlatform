using IdentityService.API.Grpc;
using IdentityService.Application;
using IdentityService.Infrastructure;
using IdentityService.Persistence;
using IdentityService.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.API.Extensions;

public static class SetupApplicationExtensions
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
            app.ApplyAutoMigrationIfEnabled();
        }

        app.MapGrpcService<IdentityGrpcServer>();

        return app;
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