using UserService.Domain.Exceptions;

namespace UserService.Domain.Entities;

public sealed class Guest : Entity<Guid>
{
    private Guest(Guid userProfileId)
    {
        Id = Guid.NewGuid();
        UserProfileId = userProfileId;
    }

    public Guid UserProfileId { get; private set; }

    public static Guest Create(Guid userProfileId)
    {
        if (userProfileId == Guid.Empty)
            throw new DomainException($"{nameof(userProfileId)} cannot be empty.");

        return new Guest(userProfileId);
    }
}