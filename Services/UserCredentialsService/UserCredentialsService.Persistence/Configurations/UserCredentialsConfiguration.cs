using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserCredentialsService.Domain.Entities;
using UserCredentialsService.Domain.ValueObjects;

namespace UserCredentialsService.Persistence.Configurations;

public class UserCredentialsConfiguration : IEntityTypeConfiguration<UserCredentials>
{
    public void Configure(EntityTypeBuilder<UserCredentials> builder)
    {
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
            .HasColumnType("VARCHAR")
            .HasMaxLength(Phone.MaxLength);
    }
}