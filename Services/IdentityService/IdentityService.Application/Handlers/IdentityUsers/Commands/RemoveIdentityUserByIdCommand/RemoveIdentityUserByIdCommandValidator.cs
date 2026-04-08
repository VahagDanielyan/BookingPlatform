using FluentValidation;

namespace IdentityService.Application.Handlers.IdentityUsers.Commands.RemoveIdentityUserByIdCommand;

public class RemoveIdentityUserByIdCommandValidator : AbstractValidator<RemoveIdentityUserByIdCommand>
{
    public RemoveIdentityUserByIdCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}