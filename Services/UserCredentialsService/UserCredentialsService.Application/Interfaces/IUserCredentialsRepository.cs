using UserCredentialsService.Domain.Entities;

namespace UserCredentialService.Application.Interfaces;

public interface IUserCredentialsRepository
{
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> ExistsByPhoneAsync(string phone, CancellationToken cancellationToken);
    Task<UserCredentials?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(UserCredentials entity, CancellationToken cancellationToken);

    Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken);
}