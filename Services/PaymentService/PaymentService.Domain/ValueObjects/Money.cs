using PaymentService.Domain.Enums;
using PaymentService.Domain.Exceptions;

namespace PaymentService.Domain.ValueObjects;

public sealed class Money : ValueObject
{
    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }

    public Currency Currency { get; }

    public static Money Create(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new DomainException($"{nameof(Amount)} cannot be negative");

        return new Money(amount, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}