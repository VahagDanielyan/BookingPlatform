using PropertyService.Domain.Enums;
using PropertyService.Domain.Exceptions;
using PropertyService.Domain.ValueObjects;

namespace PropertyService.Domain.Entities;

public sealed class Property : AggregateRoot<Guid>
{
    private const int MinRoomCount = 1;
    private readonly List<Room> _rooms = new();

    private Property(
        Guid ownerId,
        string name,
        Address address)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Name = name;
        Address = address;
        Status = PropertyStatus.Draft;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid OwnerId { get; private set; }

    public string Name { get; private set; }

    public Address Address { get; private set; }

    public PropertyStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<Room> Rooms => _rooms;

    public static Property Create(Guid ownerId, string name, Address address)
    {
        if (ownerId == Guid.Empty)
            throw new DomainException($"{nameof(ownerId)} cannot be empty.");
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException($"{nameof(name)} cannot be empty or whitespace.");
        

        return new Property(ownerId, name, address);
    }

    public void AddRoom(Room room)
    {
        if (_rooms.Any(x => x.Id == room.Id))
            throw new DomainException($"{nameof(Room)} with id {room.Id} is already added.");

        _rooms.Add(room);
    }

    public void Publish()
    {
        if (Status == PropertyStatus.Published)
            throw new DomainException($"{nameof(Property)} is already {nameof(PropertyStatus.Published)}.");
        if (_rooms.Count < MinRoomCount)
            throw new DomainException($"{nameof(Property)} must contain at least {MinRoomCount} {nameof(Room)}s");

        Status = PropertyStatus.Published;
    }

    public void Archive()
    {
        if (Status == PropertyStatus.Archived)
            throw new DomainException($"{nameof(Property)} is already {nameof(PropertyStatus.Archived)}.");

        Status = PropertyStatus.Archived;
    }
}