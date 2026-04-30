using UserService.API.Extensions;
using UserService.API.Middleware;

namespace UserService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.SetupAndAddProblemDetailsResponse();
        services.AddExceptionHandler<ExceptionHandlerMiddleware>();
        services.AddControllers();
        services.SetupAndAddSwaggerSettings(configuration);
        services.SetupAndAddValidators();
        services.AddMapster();
        services.SetupAndAddMediatR();

        return services;
    }
}