using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services;
    }
}