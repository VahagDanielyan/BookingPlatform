using IdentityService.Application.DTOs;

namespace IdentityService.Application.Interfaces;

public interface IIdentityUserService
{
    Task<Guid> AddIdentityUserAsync(AddIdentityUserRequest request, CancellationToken cancellationToken);

    Task RemoveIdentityUserByIdAsync(Guid identityUserId, CancellationToken cancellationToken);
}