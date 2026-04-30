using Microsoft.EntityFrameworkCore;
using UserCredentialService.Application.Interfaces;
using UserCredentialsService.Domain.Entities;
using UserCredentialsService.Persistence.Database;

namespace UserCredentialsService.Persistence.Repositories;

public class UserCredentialsRepository : IUserCredentialsRepository
{
    private readonly BpUserCredentialsServiceDbContext _dbContext;

    public UserCredentialsRepository(BpUserCredentialsServiceDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<bool> ExistsByPhoneAsync(string phone, CancellationToken cancellationToken) =>
        await _dbContext
            .UserCredentials
            .AnyAsync(iu => iu.Phone.Value == phone, cancellationToken);

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken) =>
        await _dbContext
            .UserCredentials
            .AnyAsync(iu => iu.Email.Value == email, cancellationToken);

    public async Task<UserCredentials?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _dbContext
            .UserCredentials
            .FirstOrDefaultAsync(iu => iu.Id == id, cancellationToken);

    public async Task AddAsync(UserCredentials entity, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _dbContext.UserCredentials
            .Where(iu => iu.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
}