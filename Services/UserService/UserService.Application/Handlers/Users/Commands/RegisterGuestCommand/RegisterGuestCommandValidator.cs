using FluentValidation;

namespace UserService.Application.Handlers.Users.Commands.RegisterGuestCommand;

public class RegisterGuestCommandValidator : AbstractValidator<RegisterGuestCommand>
{
    public RegisterGuestCommandValidator()
    {
        // RuleFor(x => x.Email)
        //     .NotEmpty()
        //     .EmailAddress()
        //     .MaximumLength(Email.MaxLength);
        //
        // RuleFor(x => x.Phone)
        //     .NotEmpty()
        //     .Must(phone => RegexPatterns.InternationalPhone().IsMatch(phone))
        //     .WithMessage("Phone number is not valid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(100)
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"\d").WithMessage("Password must contain at least one number")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character");
    }
}