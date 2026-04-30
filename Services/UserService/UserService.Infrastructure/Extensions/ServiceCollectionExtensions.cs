using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupAndAddUserCredentailsGrpcServiceClient(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddGrpcClient<UserCredentialsService.Grpc.UserCredentialsService.UserCredentialsServiceClient>(options =>
                options.Address = new Uri(configuration["GrpcSettings:UserCredentialsServiceUrl"] ??
                                          throw new InvalidOperationException("UserCredentialsServiceUrl is not set")));

        return services;
    }

    public static IServiceCollection SetupAndAddKafkaEventProducer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}