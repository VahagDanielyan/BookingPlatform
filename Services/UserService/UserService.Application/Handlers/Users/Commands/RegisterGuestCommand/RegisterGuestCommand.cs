using MediatR;

namespace UserService.Application.Handlers.Users.Commands.RegisterGuestCommand;

public record RegisterGuestCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Password
) : IRequest<Guid>;