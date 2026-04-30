using FluentValidation;

namespace UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RemoveUserCredentialsByIdCommand;

public class RemoveUserCredentialsByIdCommandValidator : AbstractValidator<RemoveUserCredentialsByIdCommand>
{
    public RemoveUserCredentialsByIdCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}