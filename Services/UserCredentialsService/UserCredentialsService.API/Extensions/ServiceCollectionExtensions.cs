using System.Reflection;
using FluentValidation;
using Mapster;
using MapsterMapper;
using UserCredentialsService.API.Interceptors;

namespace UserCredentialsService.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupAndAddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly(), typeof(Infrastructure.DependencyInjection).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();

        return services;
    }

    public static IServiceCollection SetupAndAddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(
            typeof(DependencyInjection).Assembly,
            typeof(UserCredentialService.Application.DependencyInjection).Assembly));

        return services;
    }

    public static IServiceCollection SetupAndAddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(DependencyInjection).Assembly,
            ServiceLifetime.Singleton);

        return services;
    }

    public static IServiceCollection SetupAndAddGrpc(this IServiceCollection services)
    {
        services.AddGrpc(options => options.Interceptors.Add<ExceptionInterceptor>());

        return services;
    }
}