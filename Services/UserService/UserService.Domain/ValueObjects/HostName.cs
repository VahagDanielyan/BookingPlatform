using UserService.Domain.Common;
using UserService.Domain.Exceptions;

namespace UserService.Domain.ValueObjects;

public sealed class HostName : ValueObject
{
    private const int MaxLength = 128;
    private const int MinLength = 3;


    private HostName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static HostName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{nameof(HostName)} cannot be null or whitespace.");

        if (value.Length > MaxLength)
            throw new DomainException($"{nameof(HostName)} cannot exceed {MaxLength} characters.");

        if (value.Length < MinLength)
            throw new DomainException($"{nameof(HostName)} must contain at least {MinLength} characters.");

        if (!RegexPatterns.LatinOnlyWithSingleSpaces().IsMatch(value))
            throw new DomainException($"{nameof(HostName)} must contain only Latin letters and single spaces.");

        return new HostName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}