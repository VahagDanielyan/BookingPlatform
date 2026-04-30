using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;
using UserService.Persistence.Extensions;
using UserService.Persistence.Repositories;

namespace UserService.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.SetupAndAddBpUserServiceDbContext();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}