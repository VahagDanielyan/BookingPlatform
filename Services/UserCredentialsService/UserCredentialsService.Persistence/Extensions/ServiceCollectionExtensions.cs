using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserCredentialsService.Persistence.Database;

namespace UserCredentialsService.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupAndAddUserCredentialsServiceDbContext(this IServiceCollection services)
    {
        services.AddDbContext<BpUserCredentialsServiceDbContext>(options =>
            options.UseNpgsql(builder =>
                builder.MigrationsAssembly(typeof(DependencyInjection).Assembly)));

        return services;
    }
}