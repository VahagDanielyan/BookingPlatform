using Extensions.Hosting.AsyncInitialization;
using IdentityService.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence;

public class IdentityDbContextInitializer(BpIdentityServiceDbContext bpIdentityServiceDbContext) : IAsyncInitializer
{
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        if ((await bpIdentityServiceDbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await bpIdentityServiceDbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}