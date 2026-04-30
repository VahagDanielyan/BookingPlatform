using UserService.Application.DTOs;

namespace UserService.Application.Interfaces;

public interface IUserCredentialsService
{
    Task<Guid> RegisterUserCredentialsAsync(
        RegisterUserCredentailsRequest registerUserCredentialsRequest,
        CancellationToken cancellationToken);

    Task RemoveUserCredentialsIdAsync(Guid id, CancellationToken cancellationToken = default);
}