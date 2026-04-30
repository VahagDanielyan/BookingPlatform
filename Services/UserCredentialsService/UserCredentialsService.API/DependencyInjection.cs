using UserCredentialsService.API.Extensions;

namespace UserCredentialsService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.SetupAndAddValidators();
        services.SetupAndAddMapster();
        services.SetupAndAddMediatR();
        services.SetupAndAddGrpc();

        return services;
    }
}