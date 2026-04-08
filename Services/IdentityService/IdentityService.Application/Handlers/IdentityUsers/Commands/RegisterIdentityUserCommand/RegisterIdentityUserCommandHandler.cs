using IdentityService.Application.DTOs;
using IdentityService.Application.Interfaces;
using IdentityService.Domain.Enums;
using MapsterMapper;
using MediatR;

namespace IdentityService.Application.Handlers.IdentityUsers.Commands.RegisterIdentityUserCommand;

public class RegisterIdentityUserCommandHandler : IRequestHandler<RegisterIdentityUserCommand, Guid>
{
    private readonly IIdentityUserService _identityUserUserService;
    private readonly IPasswordHasherService _passwordHasherService;

    public RegisterIdentityUserCommandHandler(
        IIdentityUserService identityUserUserService,
        IPasswordHasherService passwordHasherService
    )
    {
        _identityUserUserService = identityUserUserService;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<Guid> Handle(
        RegisterIdentityUserCommand registerIdentityUserCommand,
        CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasherService.Generate(registerIdentityUserCommand.Password);

        var identityUserId = await _identityUserUserService.AddIdentityUserAsync(
            new AddIdentityUserRequest(
                registerIdentityUserCommand.Email,
                registerIdentityUserCommand.Phone,
                passwordHash,
                registerIdentityUserCommand.Role),
            cancellationToken);

        return identityUserId;
    }
}