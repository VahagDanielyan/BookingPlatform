using UserCredentialService.Application.DTOs;

namespace UserCredentialService.Application.Interfaces;

public interface IUserCredentialsService
{
    Task<Guid> AddUserCredentialsAsync(AddUserCredentialsRequest credentialsRequest, CancellationToken cancellationToken);

    Task RemoveUserCredentialsByIdAsync(Guid id, CancellationToken cancellationToken);
}