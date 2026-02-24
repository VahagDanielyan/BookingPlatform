using FluentValidation;
using PropertyService.API.Configurations;
using PropertyService.API.Extensions;

namespace PropertyService.API;

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

        return services;
    }
}