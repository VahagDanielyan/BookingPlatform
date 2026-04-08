using UserService.Application.DTOs;

namespace UserService.Application.Interfaces;

public interface IIdentityService
{
    Task<Guid> RegisterIdentityGuestAsync(
        RegisterIdentityGuestRequest request,
        CancellationToken cancellationToken);

    Task RemoveIdentityByIdAsync(Guid identityUserId, CancellationToken cancellationToken);
}