using FluentValidation;
using IdentityService.API.Extensions;

namespace IdentityService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(DependencyInjection).Assembly,
            ServiceLifetime.Singleton);
        services.AddMapster();
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(
            typeof(DependencyInjection).Assembly,
            typeof(Application.DependencyInjection).Assembly));
        services.AddGrpc();

        return services;
    }
}