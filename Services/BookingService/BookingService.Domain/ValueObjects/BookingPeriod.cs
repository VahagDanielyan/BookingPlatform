using BookingService.Domain.Exceptions;

namespace BookingService.Domain.ValueObjects;

public sealed class BookingPeriod : ValueObject
{
    private const int MinBookingPeriodMinutes = 60;

    private BookingPeriod(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public DateTime Start { get; }
    public DateTime End { get; }

    public static BookingPeriod Create(DateTime start, DateTime end)
    {
        if (end <= start)
            throw new DomainException($"{nameof(BookingPeriod)} end must be greater than {nameof(start)}.");
        if (end - start < TimeSpan.FromMinutes(MinBookingPeriodMinutes))
            throw new DomainException($"{nameof(BookingPeriod)} must be at least {MinBookingPeriodMinutes} minutes.");

        return new BookingPeriod(start, end);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}