using IdentityService.Domain.Exceptions;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Entities;

public sealed class IdentityUser : AggregateRoot<Guid>
{
    private IdentityUser(
        Email email,
        Phone phone,
        PasswordHash passwordHash)
    {
        Id = Guid.NewGuid();
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
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

    public static IdentityUser Create(Email email, Phone phone, PasswordHash passwordHash) =>
        new(email, phone, passwordHash);
}