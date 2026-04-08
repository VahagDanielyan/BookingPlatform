using IdentityService.Application.DTOs;
using IdentityService.Application.Interfaces;
using IdentityService.Domain.Entities;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Application.Services;

public class IdentityUserService : IIdentityUserService
{
    private readonly IIdentityUserRepository _identityUserRepository;

    public IdentityUserService(IIdentityUserRepository identityUserRepository)
    {
        _identityUserRepository = identityUserRepository;
    }

    public async Task<Guid> AddIdentityUserAsync(
        AddIdentityUserRequest request,
        CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);
        var phone = Phone.Create(request.Phone);

        var identityUser = IdentityUser.Create(
            email,
            phone,
            request.PasswordHash,
            request.IdentityRole);

        await _identityUserRepository.AddAsync(identityUser, cancellationToken);

        return identityUser.Id;
    }

    public async Task RemoveIdentityUserByIdAsync(Guid identityUserId, CancellationToken cancellationToken) =>
        await _identityUserRepository.RemoveByIdAsync(identityUserId, cancellationToken);
}