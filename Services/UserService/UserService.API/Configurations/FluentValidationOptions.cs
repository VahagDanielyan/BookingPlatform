using FluentValidation;
using Microsoft.Extensions.Options;

namespace UserService.API.Configurations;

public class FluentValidationOptions<T> : IValidateOptions<T> where T : class
{
    private readonly IValidator<T> _validator;

    public FluentValidationOptions(IValidator<T> validator)
    {
        _validator = validator;
    }

    public ValidateOptionsResult Validate(string? name, T options)
    {
        var result = _validator.Validate(options);

        if (result.IsValid)
            return ValidateOptionsResult.Success;

        var errors = result.Errors.Select(e => e.ErrorMessage);

        return ValidateOptionsResult.Fail(errors);
    }
}