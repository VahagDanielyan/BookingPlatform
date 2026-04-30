using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserCredentialsService.Domain.Entities;

namespace UserCredentialsService.Persistence.Database;

public class BpUserCredentialsServiceDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public BpUserCredentialsServiceDbContext(IConfiguration configuration) => _configuration = configuration;

    public DbSet<UserCredentials> UserCredentials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("BPUserCredentialsServiceDBConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BpUserCredentialsServiceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}