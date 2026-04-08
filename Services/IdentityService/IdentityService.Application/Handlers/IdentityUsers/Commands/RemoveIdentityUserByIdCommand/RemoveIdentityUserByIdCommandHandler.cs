using MediatR;

namespace IdentityService.Application.Handlers.IdentityUsers.Commands.RemoveIdentityUserByIdCommand;

public class RemoveIdentityUserByIdCommandHandler : IRequestHandler<RemoveIdentityUserByIdCommand>
{
    private readonly Interfaces.IIdentityUserService _identityUserUserService;

    public RemoveIdentityUserByIdCommandHandler(Interfaces.IIdentityUserService identityUserUserService) =>
        _identityUserUserService = identityUserUserService;

    public async Task Handle(RemoveIdentityUserByIdCommand removeIdentityUserByIdCommand,
        CancellationToken cancellationToken) =>
        await _identityUserUserService.RemoveIdentityUserByIdAsync(removeIdentityUserByIdCommand.Id, cancellationToken);
}