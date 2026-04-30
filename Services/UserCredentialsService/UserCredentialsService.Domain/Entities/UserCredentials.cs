using Shared.Domain.Enums;
using Shared.Domain.Exceptions;
using UserCredentialsService.Domain.ValueObjects;

namespace UserCredentialsService.Domain.Entities;

public sealed class UserCredentials : AggregateRoot<Guid>
{
    private UserCredentials(
        Email email,
        Phone phone,
        string passwordHash,
        UserRole userRole)
    {
        Id = Guid.NewGuid();
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        UserRole = userRole;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRole UserRole { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public void Deactivate()
    {
        if (!IsActive)
            throw new ConflictDomainException("User already inactive.");

        IsActive = false;
    }

    public void ChangePassword(string newPasswordHash)
    {
        if (PasswordHash == newPasswordHash)
            throw new ConflictDomainException($"Password cannot be same.");

        PasswordHash = newPasswordHash;
    }

    public static UserCredentials Create(Email email, Phone phone, string passwordHash, UserRole userRole) =>
        new(email, phone, passwordHash, userRole);
}