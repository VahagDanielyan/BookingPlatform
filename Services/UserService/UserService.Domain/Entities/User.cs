using UserService.Domain.ValueObjects;

namespace UserService.Domain.Entities;

public sealed class User : AggregateRoot<Guid>
{
    private User(Guid identityUserId, FirstName firstName, LastName lastName)
    {
        Id = Guid.NewGuid();
        IdentityUserId = identityUserId;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid IdentityUserId { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static User Create(Guid identityUserId, FirstName firstName, LastName lastName) =>
        new(identityUserId, firstName, lastName);
}