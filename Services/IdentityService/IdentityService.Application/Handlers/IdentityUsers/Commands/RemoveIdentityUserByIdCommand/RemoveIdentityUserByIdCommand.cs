using MediatR;

namespace IdentityService.Application.Handlers.IdentityUsers.Commands.RemoveIdentityUserByIdCommand;

public record RemoveIdentityUserByIdCommand(Guid Id) : IRequest;