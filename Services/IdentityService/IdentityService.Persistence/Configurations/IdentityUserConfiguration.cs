using IdentityService.Domain.Entities;
using IdentityService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityService.Persistence.Configurations;

public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
            .HasConversion(
                x => x.Value,
                value => Email.Create(value))
            .HasColumnType("VARCHAR")
            .HasMaxLength(Email.MaxLength);

        builder.Property(x => x.Phone)
            .HasConversion(
                phone => phone.Value,
                value => Phone.Create(value))
            .HasMaxLength(Phone.MaxLength)
            .HasColumnType("VARCHAR");

        builder.Property(x => x.PasswordHash)
            .HasConversion(
                hash => hash.Value,
                value => PasswordHash.Create(value))
            .HasColumnType("VARCHAR");
    }
}