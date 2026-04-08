using IdentityService.Application.Interfaces;
using IdentityService.Persistence.Database;
using IdentityService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BpIdentityServiceDbContext>(options =>
            options.UseNpgsql(builder =>
                builder.MigrationsAssembly(typeof(DependencyInjection).Assembly)));
        services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();

        return services;
    }
}