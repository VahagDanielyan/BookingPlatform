using UserService.Domain.Exceptions;
using UserService.Domain.ValueObjects;

namespace UserService.Domain.Entities;

public sealed class Host : Entity<Guid>
{
    private Host(Guid userProfileId, HostName hostName)
    {
        Id = Guid.NewGuid();
        UserProfileId = userProfileId;
        HostName = hostName;
    }

    public Guid UserProfileId { get; private set; }
    public HostName HostName { get; private set; }

    public static Host Create(Guid userProfileId, HostName hostName)
    {
        if (userProfileId == Guid.Empty)
            throw new DomainException($"{nameof(userProfileId)} cannot be empty.");

        return new Host(userProfileId, hostName);
    }
}