using FluentValidation;
using PaymentService.API.Extensions;
using PaymentService.API.Configurations;

namespace PaymentService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddValidatorsFromAssembly(
            typeof(PaymentService.API.DependencyInjection).Assembly,
            ServiceLifetime.Singleton);
        services.AddOptions<SwaggerSettings>()
            .Bind(configuration.GetSection(nameof(SwaggerSettings)))
            .ValidateFluentValidation()
            .ValidateOnStart();

        return services;
    }
}