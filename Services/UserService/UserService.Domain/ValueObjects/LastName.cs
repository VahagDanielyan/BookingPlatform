using UserService.Domain.Common;
using UserService.Domain.Exceptions;

namespace UserService.Domain.ValueObjects;

public sealed class LastName : ValueObject
{
    private const int MaxLength = 30;
    private const int MinLength = 3;


    private LastName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static LastName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{nameof(LastName)} cannot be null or whitespace.");
        if (value.Length > MaxLength)
            throw new DomainException($"{nameof(LastName)} cannot exceed {MaxLength} characters.");
        if (value.Length < MinLength)
            throw new DomainException($"{nameof(LastName)} must contain at least {MinLength} characters.");
        if (!RegexPatterns.LatinOnly().IsMatch(value))
            throw new DomainException($"{nameof(LastName)} must contain only Latin letters and no spaces.");

        return new LastName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}