using Microsoft.Extensions.DependencyInjection;
using UserCredentialService.Application.Interfaces;
using UserCredentialService.Application.Services;

namespace UserCredentialService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        services.AddScoped<Interfaces.IUserCredentialsService, Services.UserCredentialsService>();

        return services;
    }
}