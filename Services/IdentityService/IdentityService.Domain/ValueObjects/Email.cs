using IdentityService.Domain.Common;
using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public const int MaxLength = 254;
    private Email(string value) => Value = value;

    public string Value { get; }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{nameof(Email)} cannot be null or whitespace.");

        if (value.Length > MaxLength)
            throw new DomainException($"{nameof(Email)} cannot exceed {MaxLength} characters.");

        if (!RegexPatterns.ValidEmailFormat().IsMatch(value))
            throw new DomainException($"{nameof(Email)} has invalid format.");

        return new Email(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}