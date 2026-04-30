using Microsoft.Extensions.DependencyInjection;
using UserCredentialService.Application.Interfaces;
using UserCredentialsService.Persistence.Extensions;
using UserCredentialsService.Persistence.Repositories;

namespace UserCredentialsService.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.SetupAndAddUserCredentialsServiceDbContext();
        services.AddScoped<IUserCredentialsRepository, UserCredentialsRepository>();

        return services;
    }
}