using System.Reflection;
using IdentityService.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BpIdentityServiceDbContext>(options =>
            options.UseNpgsql(builder =>
                builder.MigrationsAssembly(typeof(IdentityService.Persistence.DependencyInjection).Assembly)));
        services.AddAsyncInitializer<IdentityDbContextInitializer>();

        return services;
    }
}