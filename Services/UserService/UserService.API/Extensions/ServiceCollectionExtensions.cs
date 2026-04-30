using System.Reflection;
using FluentValidation;
using Mapster;
using MapsterMapper;
using UserService.API.Configurations;

namespace UserService.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupAndAddProblemDetailsResponse(
        this IServiceCollection services) =>
        services.AddProblemDetails(config => config.CustomizeProblemDetails = problemDetailsContext =>
        {
            problemDetailsContext.ProblemDetails.Extensions.Remove("traceId");
            problemDetailsContext.ProblemDetails.Extensions.Remove("title");
            problemDetailsContext.ProblemDetails.Type = null;
        });

    public static IServiceCollection AddMapster(this IServiceCollection services)
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
            typeof(Application.DependencyInjection).Assembly));

        return services;
    }

    public static IServiceCollection SetupAndAddSwaggerSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSwaggerGen();
        
        services.AddOptions<SwaggerSettings>()
            .Bind(configuration.GetSection(nameof(SwaggerSettings)))
            .ValidateFluentValidation()
            .ValidateOnStart();

        return services;
    }

    public static IServiceCollection SetupAndAddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(DependencyInjection).Assembly,
            ServiceLifetime.Singleton);

        return services;
    }
}