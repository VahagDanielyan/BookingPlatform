using IdentityService.Domain.Enums;
using MediatR;

namespace IdentityService.Application.Handlers.IdentityUsers.Commands.RegisterIdentityUserCommand;

public record RegisterIdentityUserCommand(
    string Email,
    string Phone,
    string Password,
    IdentityRole Role
) : IRequest<Guid>;