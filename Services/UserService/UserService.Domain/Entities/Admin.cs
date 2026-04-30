using Shared.Domain.Exceptions;

namespace UserService.Domain.Entities;

public sealed class Admin : Entity<Guid>
{
    private Admin(Guid userProfileId)
    {
        Id = Guid.NewGuid();
        UserProfileId = userProfileId;
    }

    public Guid UserProfileId { get; private set; }

    public static Admin Create(Guid userProfileId)
    {
        if (userProfileId == Guid.Empty)
            throw new ValidationDomainException($"{nameof(userProfileId)} cannot be empty.");

        return new Admin(userProfileId);
    }
}