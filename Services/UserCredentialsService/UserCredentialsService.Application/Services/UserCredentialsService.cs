using UserCredentialService.Application.DTOs;
using UserCredentialService.Application.Interfaces;
using UserCredentialsService.Domain.Entities;
using UserCredentialsService.Domain.ValueObjects;

namespace UserCredentialService.Application.Services;

public class UserCredentialsService : Interfaces.IUserCredentialsService
{
    private readonly IUserCredentialsRepository _userCredentialsRepository;

    public UserCredentialsService(IUserCredentialsRepository userCredentialsRepository) =>
        _userCredentialsRepository = userCredentialsRepository;

    public async Task<Guid> AddUserCredentialsAsync(
        AddUserCredentialsRequest credentialsRequest,
        CancellationToken cancellationToken)
    {
        var email = Email.Create(credentialsRequest.Email);
        var phone = Phone.Create(credentialsRequest.Phone);

        var userCredentials = UserCredentials.Create(
            email,
            phone,
            credentialsRequest.PasswordHash,
            credentialsRequest.UserRole);

        await _userCredentialsRepository.AddAsync(userCredentials, cancellationToken);

        return userCredentials.Id;
    }

    public async Task RemoveUserCredentialsByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _userCredentialsRepository.RemoveByIdAsync(id, cancellationToken);
}