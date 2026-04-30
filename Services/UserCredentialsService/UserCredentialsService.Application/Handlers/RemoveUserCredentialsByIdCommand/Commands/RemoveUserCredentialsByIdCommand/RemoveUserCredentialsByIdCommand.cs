using MediatR;

namespace UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RemoveUserCredentialsByIdCommand;

public record RemoveUserCredentialsByIdCommand(Guid Id) : IRequest;