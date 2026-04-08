using FluentValidation;
using UserService.API.Configurations;
using UserService.API.Extensions;

namespace UserService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddValidatorsFromAssembly(
            typeof(DependencyInjection).Assembly,
            ServiceLifetime.Singleton);
        services.AddOptions<SwaggerSettings>()
            .Bind(configuration.GetSection(nameof(SwaggerSettings)))
            .ValidateFluentValidation()
            .ValidateOnStart();
        services.AddMapster();
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(
            typeof(DependencyInjection).Assembly,
            typeof(Application.DependencyInjection).Assembly));

        return services;
    }
}