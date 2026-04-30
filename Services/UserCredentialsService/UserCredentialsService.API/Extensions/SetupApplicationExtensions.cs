using Microsoft.EntityFrameworkCore;
using UserCredentialService.Application;
using UserCredentialsService.Infrastructure;
using UserCredentialsService.Persistence;
using UserCredentialsService.Persistence.Database;

namespace UserCredentialsService.API.Extensions;

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
        
        app.MapGrpcService<Grpc.UserCredentialsGrpcService>();

        return app;
    }

    private static void ApplyAutoMigrationIfEnabled(this WebApplication app)
    {
        var isAutoMigrationEnabled = app.Configuration.GetValue<bool>("IsAutoMigrationEnabled");

        if (!isAutoMigrationEnabled) return;

        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BpUserCredentialsServiceDbContext>();

        db.Database.Migrate();
    }
}