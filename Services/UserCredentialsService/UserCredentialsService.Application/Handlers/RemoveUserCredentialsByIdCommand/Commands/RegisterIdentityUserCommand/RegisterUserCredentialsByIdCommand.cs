using MediatR;
using Shared.Domain.Enums;

namespace UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RegisterIdentityUserCommand;

public record RegisterUserCredentialsByIdCommand(
    string Email,
    string Phone,
    string Password,
    UserRole UserRole
) : IRequest<Guid>;