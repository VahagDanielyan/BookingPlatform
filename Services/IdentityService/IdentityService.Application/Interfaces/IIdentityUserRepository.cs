using IdentityService.Domain.Entities;

namespace IdentityService.Application.Interfaces;

public interface IIdentityUserRepository
{
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> ExistsByPhoneAsync(string phone, CancellationToken cancellationToken);
    Task<IdentityUser?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(IdentityUser entity, CancellationToken cancellationToken);

    Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken);
}