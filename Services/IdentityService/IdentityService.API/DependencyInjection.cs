using FluentValidation;
using IdentityService.API.Configurations;
using IdentityService.API.Extensions;

namespace IdentityService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddValidatorsFromAssembly(
            typeof(API.DependencyInjection).Assembly,
            ServiceLifetime.Singleton);
        services.AddOptions<SwaggerSettings>()
            .Bind(configuration.GetSection(nameof(SwaggerSettings)))
            .ValidateFluentValidation()
            .ValidateOnStart();

        return services;
    }
}