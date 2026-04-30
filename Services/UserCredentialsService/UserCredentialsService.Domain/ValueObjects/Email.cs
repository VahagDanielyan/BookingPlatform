using Shared.Domain.Exceptions;
using UserCredentialsService.Domain.Common;

namespace UserCredentialsService.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public const int MaxLength = 254;
    private Email(string value) => Value = value;

    public string Value { get; }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationDomainException($"{nameof(Email)} cannot be null or whitespace.");

        if (value.Length > MaxLength)
            throw new ValidationDomainException($"{nameof(Email)} cannot exceed {MaxLength} characters.");

        if (!RegexPatterns.ValidEmailFormat().IsMatch(value))
            throw new ValidationDomainException($"{nameof(Email)} has invalid format.");

        return new Email(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}