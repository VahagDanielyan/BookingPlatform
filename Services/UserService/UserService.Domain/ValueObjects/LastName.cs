using Shared.Domain.Exceptions;
using UserService.Domain.Common;

namespace UserService.Domain.ValueObjects;

public sealed class LastName : ValueObject
{
    public const int MaxLength = 30;
    public const int MinLength = 3;


    private LastName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static LastName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationDomainException($"{nameof(LastName)} cannot be null or whitespace.");

        if (value.Length > MaxLength)
            throw new ValidationDomainException($"{nameof(LastName)} cannot exceed {MaxLength} characters.");

        if (value.Length < MinLength)
            throw new ValidationDomainException($"{nameof(LastName)} must contain at least {MinLength} characters.");

        if (!RegexPatterns.LatinOnly().IsMatch(value))
            throw new ValidationDomainException($"{nameof(LastName)} must contain only Latin letters and no spaces.");

        return new LastName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}