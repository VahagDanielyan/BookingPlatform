using PropertyService.Domain.Common;
using PropertyService.Domain.Exceptions;

namespace PropertyService.Domain.ValueObjects;

public sealed class PropertyName : ValueObject
{
    private const int MinLength = 3;
    private const int MaxLength = 100;

    private PropertyName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static PropertyName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{nameof(PropertyName)} cannot be null or whitespace.");
        if (value.Length < MinLength)
            throw new DomainException($"{nameof(PropertyName)} cannot be less than {MinLength} characters.");
        if (value.Length > MaxLength)
            throw new DomainException($"{nameof(PropertyName)} cannot exceed {MaxLength} characters.");
        if (!RegexPatterns.LatinOnlyWithSingleSpaces().IsMatch(value))
            throw new DomainException($"{nameof(PropertyName)} must contain only latin letters and single spaces.");

        return new PropertyName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}