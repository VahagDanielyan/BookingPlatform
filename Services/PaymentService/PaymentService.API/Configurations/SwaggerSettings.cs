namespace PaymentService.API.Configurations;

public sealed class SwaggerSettings
{
    public bool IsEnabled { get; init; }
    public string Title { get; init; } = null!;
    public string Endpoint { get; init; } = null!;
    public string RoutePrefix { get; init; } = null!;
}