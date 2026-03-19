using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Persistence.Database;

namespace UserService.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BpUserServiceDbContext>(options =>
            options.UseNpgsql(builder =>
                builder.MigrationsAssembly(typeof(Persistence.DependencyInjection).Assembly)));
        
        return services;
    }
}