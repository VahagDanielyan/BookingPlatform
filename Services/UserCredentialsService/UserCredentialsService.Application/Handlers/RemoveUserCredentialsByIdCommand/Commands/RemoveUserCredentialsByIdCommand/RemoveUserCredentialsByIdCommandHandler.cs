using MediatR;
using UserCredentialService.Application.Interfaces;

namespace UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RemoveUserCredentialsByIdCommand;

public class RemoveUserCredentialsByIdCommandHandler : IRequestHandler<RemoveUserCredentialsByIdCommand>
{
    private readonly IUserCredentialsService _userCredentialsUserCredentialsService;

    public RemoveUserCredentialsByIdCommandHandler(IUserCredentialsService userCredentialsUserCredentialsService) =>
        _userCredentialsUserCredentialsService = userCredentialsUserCredentialsService;

    public async Task Handle(RemoveUserCredentialsByIdCommand removeUserCredentialsByIdCommand,
        CancellationToken cancellationToken) =>
        await _userCredentialsUserCredentialsService.RemoveUserCredentialsByIdAsync(removeUserCredentialsByIdCommand.Id, cancellationToken);
}