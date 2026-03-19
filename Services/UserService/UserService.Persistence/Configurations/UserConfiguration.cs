using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;
using UserService.Domain.ValueObjects;

namespace UserService.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .HasConversion(
                firstName => firstName.Value,
                value => FirstName.Create(value))
            .HasColumnType("VARCHAR")
            .HasMaxLength(FirstName.MaxLength);

        builder.Property(x => x.LastName)
            .HasConversion(
                lastName => lastName.Value,
                value => LastName.Create(value))
            .HasColumnType("VARCHAR")
            .HasMaxLength(LastName.MaxLength);
    }
}