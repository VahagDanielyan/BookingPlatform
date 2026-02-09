namespace IdentityService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddControllers();

        return services;
    }
}