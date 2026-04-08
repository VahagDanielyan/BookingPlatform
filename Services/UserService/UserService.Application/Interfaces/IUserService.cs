using UserService.Application.DTOs;

namespace UserService.Application.Interfaces;

public interface IUserService
{
    Task<Guid> AddUserAsync(AddUserRequest request, CancellationToken cancellationToken);
}