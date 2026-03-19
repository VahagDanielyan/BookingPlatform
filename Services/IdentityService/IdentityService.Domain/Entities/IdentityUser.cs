using IdentityService.Domain.Enums;
using IdentityService.Domain.Exceptions;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Entities;

public sealed class IdentityUser : AggregateRoot<Guid>
{
    private IdentityUser(
        Email email,
        Phone phone,
        PasswordHash passwordHash,
        IdentityRoles roles)
    {
        Id = Guid.NewGuid();
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        Roles = roles;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public IdentityRoles Roles { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public void Deactivate()
    {
        if (!IsActive)
            throw new DomainException($"{nameof(IdentityUser)} already inactive.");

        IsActive = false;
    }

    public void ChangePassword(PasswordHash newPasswordHash)
    {
        if (PasswordHash == newPasswordHash)
            throw new DomainException($"{nameof(newPasswordHash)} cannot be same.");

        PasswordHash = newPasswordHash;
    }

    public void AddRole(IdentityRoles roles) => Roles |= roles;

    public void RemoveRole(IdentityRoles roles) => Roles &= ~roles;

    public bool HasRole(IdentityRoles roles) => (Roles & roles) == roles;

    public static IdentityUser Create(Email email, Phone phone, PasswordHash passwordHash, IdentityRoles roleses) =>
        new(email, phone, passwordHash, roleses);
}