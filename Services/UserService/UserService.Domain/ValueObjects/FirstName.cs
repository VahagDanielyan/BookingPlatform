using Shared.Domain.Exceptions;
using UserService.Domain.Common;

namespace UserService.Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 30;
    private const int MinLength = 3;

    private FirstName(string value) => Value = value;

    public string Value { get; }

    public static FirstName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationDomainException($"{nameof(FirstName)} cannot be empty or whitespace.");

        if (value.Length > MaxLength)
            throw new ValidationDomainException($"{nameof(FirstName)} cannot exceed {MaxLength} characters.");

        if (value.Length < MinLength)
            throw new ValidationDomainException($"{nameof(FirstName)} must contain at least {MinLength} characters.");

        if (!RegexPatterns.LatinOnly().IsMatch(value))
            throw new ValidationDomainException($"{nameof(FirstName)} must contain only Latin letters and no spaces.");

        return new FirstName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}