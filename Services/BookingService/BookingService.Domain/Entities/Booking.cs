using BookingService.Domain.Enums;
using BookingService.Domain.Exceptions;
using BookingService.Domain.ValueObjects;

namespace BookingService.Domain.Entities;

public sealed class Booking : AggregateRoot<Guid>
{
    private Booking(
        Guid userId,
        Guid propertyId,
        Guid roomId,
        BookingPeriod period)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        PropertyId = propertyId;
        RoomId = roomId;
        Period = period;
        Status = BookingStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid UserId { get; private set; }

    public Guid PropertyId { get; private set; }

    public Guid RoomId { get; private set; }

    public BookingPeriod Period { get; private set; }

    public BookingStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public void Confirm()
    {
        if (Status != BookingStatus.Pending)
            throw new DomainException(
                $"Only {nameof(BookingStatus.Pending)} {nameof(Booking)} can be {nameof(BookingStatus.Confirmed)}.");

        Status = BookingStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status != BookingStatus.Pending)
            throw new DomainException(
                $"Only {nameof(BookingStatus.Pending)} {nameof(Booking)} can be {nameof(BookingStatus.Cancelled)}.");

        Status = BookingStatus.Cancelled;
    }
    
    public static Booking Create(Guid userId, Guid propertyId, Guid roomId, BookingPeriod bookingPeriod) =>
        new(userId, propertyId, roomId, bookingPeriod);
}