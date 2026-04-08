using UserService.Domain.Entities;
using UserService.Application.Interfaces;
using UserService.Persistence.Database;

namespace UserService.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BpUserServiceDbContext _userServiceDbContext;

    public UserRepository(BpUserServiceDbContext userServiceDbContext) => _userServiceDbContext = userServiceDbContext;

    public async Task AddAsync(User user)
    {
        await _userServiceDbContext.Users.AddAsync(user);

        await _userServiceDbContext.SaveChangesAsync();
    }
}