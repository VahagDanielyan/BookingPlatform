using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.Domain.Entities;

namespace UserService.Persistence.Database;

public class BpUserServiceDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public BpUserServiceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("BPUserServiceDBConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BpUserServiceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}