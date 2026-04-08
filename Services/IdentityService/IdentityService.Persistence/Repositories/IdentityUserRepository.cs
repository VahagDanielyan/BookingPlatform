using IdentityService.Application.Interfaces;
using IdentityService.Domain.Entities;
using IdentityService.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence.Repositories;

public class IdentityUserRepository : IIdentityUserRepository
{
    private readonly BpIdentityServiceDbContext _bpIdentityServiceDbContext;

    public IdentityUserRepository(BpIdentityServiceDbContext bpIdentityServiceDbContext) =>
        _bpIdentityServiceDbContext = bpIdentityServiceDbContext;

    public async Task<bool> ExistsByPhoneAsync(string phone, CancellationToken cancellationToken) =>
        await _bpIdentityServiceDbContext
            .IdentityUsers
            .AnyAsync(iu => iu.Phone.Value == phone, cancellationToken);

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken) =>
        await _bpIdentityServiceDbContext
            .IdentityUsers
            .AnyAsync(iu => iu.Email.Value == email, cancellationToken);

    public async Task<IdentityUser?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _bpIdentityServiceDbContext
            .IdentityUsers
            .FirstOrDefaultAsync(iu => iu.Id == id, cancellationToken);

    public async Task AddAsync(IdentityUser entity, CancellationToken cancellationToken)
    {
        await _bpIdentityServiceDbContext.AddAsync(entity, cancellationToken);
        await _bpIdentityServiceDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _bpIdentityServiceDbContext.IdentityUsers
            .Where(iu => iu.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
}