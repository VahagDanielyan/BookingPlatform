using IdentityService.Domain.Enums;
using IdentityService.Domain.Exceptions;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Entities;

public sealed class IdentityUser : AggregateRoot<Guid>
{
    private IdentityUser(
        Email email,
        Phone phone,
        string passwordHash,
        IdentityRole role)
    {
        Id = Guid.NewGuid();
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        Role = role;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public string PasswordHash { get; private set; }
    public IdentityRole Role { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public void Deactivate()
    {
        if (!IsActive)
            throw new DomainException($"{nameof(IdentityUser)} already inactive.");

        IsActive = false;
    }

    public void ChangePassword(string newPasswordHash)
    {
        if (PasswordHash == newPasswordHash)
            throw new DomainException($"{nameof(newPasswordHash)} cannot be same.");

        PasswordHash = newPasswordHash;
    }

    public static IdentityUser Create(Email email, Phone phone, string passwordHash, IdentityRole role) =>
        new(email, phone, passwordHash, role);
}