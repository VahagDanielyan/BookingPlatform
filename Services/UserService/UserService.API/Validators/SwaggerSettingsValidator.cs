using FluentValidation;
using UserService.API.Configurations;

namespace UserService.API.Validators;

public sealed class SwaggerSettingsValidator
    : AbstractValidator<SwaggerSettings>
{
    public SwaggerSettingsValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();
        
        RuleFor(x => x.Endpoint)
            .NotEmpty();
        
        RuleFor(x => x.RoutePrefix)
            .NotNull();
    }
}