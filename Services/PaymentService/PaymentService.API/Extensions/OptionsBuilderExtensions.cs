using FluentValidation;
using Microsoft.Extensions.Options;
using PaymentService.API.Configurations;

namespace PaymentService.API.Extensions;

public static class OptionsBuilderExtensions
{
    public static OptionsBuilder<T> ValidateFluentValidation<T>(
        this OptionsBuilder<T> optionsBuilder)
        where T : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<T>>(serviceProvider =>
        {
            var validator = serviceProvider.GetRequiredService<IValidator<T>>();
            return new FluentValidationOptions<T>(validator);
        });

        return optionsBuilder;
    }
}