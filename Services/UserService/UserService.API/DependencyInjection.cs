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
            typeof(UserService.API.DependencyInjection).Assembly,
            ServiceLifetime.Singleton);
        services.AddOptions<SwaggerSettings>()
            .Bind(configuration.GetSection(nameof(SwaggerSettings)))
            .ValidateFluentValidation()
            .ValidateOnStart();

        return services;
    }
}