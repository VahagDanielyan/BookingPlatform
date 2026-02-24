using PaymentService.Domain.Enums;
using PaymentService.Domain.Exceptions;
using PaymentService.Domain.ValueObjects;

namespace PaymentService.Domain.Entities;

public sealed class Payment : AggregateRoot<Guid>
{
    private Payment(Guid bookingId, Money amount)
    {
        Id = Guid.NewGuid();
        BookingId = bookingId;
        Amount = amount;
        Status = PaymentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid BookingId { get; private set; }

    public Money Amount { get; private set; }

    public PaymentStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Payment Create(Guid bookingId, decimal amount, Currency currency)
    {
        var money = Money.Create(amount, currency);

        return new Payment(bookingId, money);
    }

    public void Complete()
    {
        if (Status != PaymentStatus.Pending)
            throw new DomainException(
                $"Only {nameof(PaymentStatus.Pending)} {nameof(Payment)} can be {nameof(PaymentStatus.Completed)}.");

        Status = PaymentStatus.Completed;
    }

    public void Fail()
    {
        Status = PaymentStatus.Failed;
    }
}