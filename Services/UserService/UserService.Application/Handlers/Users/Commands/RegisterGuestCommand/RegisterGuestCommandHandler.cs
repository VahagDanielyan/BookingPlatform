using MediatR;
using Shared.Domain.Enums;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Application.Handlers.Users.Commands.RegisterGuestCommand;

public class RegisterGuestCommandHandler : IRequestHandler<RegisterGuestCommand, Guid>
{
    private readonly IUserService _userService;
    private readonly IUserCredentialsService _userCredentialsService;

    public RegisterGuestCommandHandler(
        IUserService userService,
        IUserCredentialsService userCredentialsService)
    {
        _userService = userService;
        _userCredentialsService = userCredentialsService;
    }

    public async Task<Guid> Handle(RegisterGuestCommand registerGuestCommand, CancellationToken cancellationToken)
    {
        Guid userCredentialsId;

        try
        {
            userCredentialsId = await _userCredentialsService.RegisterUserCredentialsAsync(
                new RegisterUserCredentailsRequest(
                    registerGuestCommand.Email,
                    registerGuestCommand.Phone,
                    registerGuestCommand.Password,
                    UserRole.Guest),
                cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        try
        {
            var userId = await _userService.AddUserAsync(
                new AddUserRequest(userCredentialsId, registerGuestCommand.FirstName, registerGuestCommand.LastName),
                cancellationToken);

            return userId;
        }
        catch
        {
            await _userCredentialsService.RemoveUserCredentialsIdAsync(userCredentialsId);

            throw;
        }
    }
}