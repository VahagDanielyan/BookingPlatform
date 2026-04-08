using FluentValidation;

namespace IdentityService.Application.Handlers.IdentityUsers.Commands.RegisterIdentityUserCommand;

public class RegisterIdentityUserCommandValidator : AbstractValidator<RegisterIdentityUserCommand>
{
    public RegisterIdentityUserCommandValidator()
    {
    }
}