using Microsoft.Extensions.DependencyInjection;

namespace PropertyService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}