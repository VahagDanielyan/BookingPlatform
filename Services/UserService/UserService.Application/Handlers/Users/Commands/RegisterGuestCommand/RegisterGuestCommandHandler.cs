using MapsterMapper;
using MediatR;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Application.Handlers.Users.Commands.RegisterGuestCommand;

public class RegisterGuestCommandHandler : IRequestHandler<RegisterGuestCommand, Guid>
{
    private readonly IUserService _userService;
    private readonly IIdentityService _identityService;

    public RegisterGuestCommandHandler(IUserService userService, IIdentityService identityService, IMapper mapper)
    {
        _userService = userService;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(RegisterGuestCommand registerGuestCommand, CancellationToken cancellationToken)
    {
        var identityUserId =
            await _identityService.RegisterIdentityGuestAsync(
                new RegisterIdentityGuestRequest(
                    registerGuestCommand.Email, registerGuestCommand.Phone, registerGuestCommand.Password),
                cancellationToken);

        try
        {
            var userId = await _userService.AddUserAsync(
                new AddUserRequest(identityUserId, registerGuestCommand.FirstName, registerGuestCommand.LastName),
                cancellationToken);

            return userId;
        }
        catch
        {
            try
            {
                await _identityService.RemoveIdentityByIdAsync(identityUserId, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}, {ex.StackTrace}");
                throw;
            }

            throw;
        }
    }
}