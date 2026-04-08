using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpcClient<IdentityGrpcService.Grpc.IdentityGrpcService.IdentityGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["GrpcSettings:IdentityGrpcServiceUrl"] ??
                                      throw new InvalidOperationException("IdentityGrpcServiceUrl is not set"));
        });
        services.AddScoped<IIdentityService, Services.IdentityGrpcService>();

        return services;
    }
}