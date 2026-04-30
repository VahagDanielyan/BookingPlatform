using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Extensions;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.SetupAndAddUserCredentailsGrpcServiceClient(configuration);
        services.AddScoped<IUserCredentialsService, Services.UserCredentialsGrpcService>();
        //ToDo empty extension fix
        services.SetupAndAddKafkaEventProducer(configuration);

        return services;
    }
}