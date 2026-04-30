using MediatR;
using UserCredentialService.Application.DTOs;
using UserCredentialService.Application.Interfaces;

namespace UserCredentialService.Application.Handlers.RemoveUserCredentialsByIdCommand.Commands.RegisterIdentityUserCommand;

public class RegisterUserCredentialsCommandHandler : IRequestHandler<RegisterUserCredentialsByIdCommand, Guid>
{
    private readonly Interfaces.IUserCredentialsService _userCredentialsService;
    private readonly IPasswordHasherService _passwordHasherService;

    public RegisterUserCredentialsCommandHandler(
        IUserCredentialsService userCredentialsService,
        IPasswordHasherService passwordHasherService
    )
    {
        _userCredentialsService = userCredentialsService;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<Guid> Handle(
        RegisterUserCredentialsByIdCommand registerUserCredentialsByIdCommand,
        CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasherService.Generate(registerUserCredentialsByIdCommand.Password);

        var identityUserId = await _userCredentialsService.AddUserCredentialsAsync(
            new AddUserCredentialsRequest(
                registerUserCredentialsByIdCommand.Email,
                registerUserCredentialsByIdCommand.Phone,
                passwordHash,
                registerUserCredentialsByIdCommand.UserRole),
            cancellationToken);

        return identityUserId;
    }
}