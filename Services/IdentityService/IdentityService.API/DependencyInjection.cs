using FluentValidation;
using IdentityService.API.Extensions;
using IdentityService.API.Interceptors;

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
        services.AddGrpc(options =>
        {
            options.Interceptors.Add<GrpcExceptionInterceptor>();
        });

        return services;
    }
}