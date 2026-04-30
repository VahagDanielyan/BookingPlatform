using FluentValidation;

namespace UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RegisterIdentityUserCommand;

public class RegisterUserCredentialsCommandValidator : AbstractValidator<RegisterUserCredentialsByIdCommand>
{
    public RegisterUserCredentialsCommandValidator()
    {
    }
}