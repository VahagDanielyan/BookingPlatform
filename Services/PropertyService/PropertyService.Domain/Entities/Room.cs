using PropertyService.Domain.Common;
using PropertyService.Domain.Exceptions;

namespace PropertyService.Domain.Entities;

public sealed class Room : Entity<Guid>
{
    private const int MinCapacity = 1;
    private const int MaxCapacity = 300;

    private Room(string name, int capacity)
    {
        Id = Guid.NewGuid();
        Name = name;
        Capacity = capacity;
    }

    public string Name { get; private set; }

    public int Capacity { get; private set; }

    public static Room Create(string name, int capacity)
    {
        if (!RegexPatterns.LatinOnlyWithSingleSpaces().IsMatch(name))
            throw new DomainException($"{nameof(name)} must contain only Latin letters and single spaces.");
        if (capacity < MinCapacity)
            throw new DomainException($"{nameof(capacity)} must be greater than {MinCapacity}.");
        if (capacity > MaxCapacity)
            throw new DomainException($"{nameof(capacity)} cannot be greater than {MaxCapacity}.");

        return new Room(name, capacity);
    }
}