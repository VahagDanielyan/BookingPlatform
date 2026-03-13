using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IdentityService.Persistence.Database;

public class BpIdentityServiceDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public BpIdentityServiceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<IdentityUser> IdentityUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("BPIdentityService"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BpIdentityServiceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}