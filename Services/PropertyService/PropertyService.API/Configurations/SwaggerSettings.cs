using System.ComponentModel.DataAnnotations;

namespace PropertyService.API.Configurations;

public sealed class SwaggerSettings
{
    public const string SectionName = "SwaggerSettings";
    public bool IsEnabled { get; init; }
    [Required] public string Title { get; init; } = null!;
    [Required] public string Endpoint { get; init; } = null!;
    [Required(AllowEmptyStrings = true)] public string RoutePrefix { get; init; } = null!;
}