using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Persistence.Database;

namespace UserService.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupAndAddBpUserServiceDbContext(this IServiceCollection services)
    {
        services.AddDbContext<BpUserServiceDbContext>(options =>
            options.UseNpgsql(builder =>
                builder.MigrationsAssembly(typeof(DependencyInjection).Assembly)));

        return services;
    }
}