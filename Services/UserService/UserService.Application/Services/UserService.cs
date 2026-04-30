using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.ValueObjects;

namespace UserService.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<Guid> AddUserAsync(AddUserRequest request, CancellationToken cancellationToken)
    {
        var firstName = FirstName.Create(request.FirstName);
        var lastName = LastName.Create(request.LastName);
        var user = User.Create(request.UserCredentailsId, firstName, lastName);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}