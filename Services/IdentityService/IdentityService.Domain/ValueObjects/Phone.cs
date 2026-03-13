using IdentityService.Domain.Common;
using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.ValueObjects;

public sealed class Phone : ValueObject
{
    public const int MinLength = 7;
    public const int MaxLength = 15;

    private Phone(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Phone Create(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new DomainException($"{nameof(Phone)} cannot be null or whitespace.");

        if (!RegexPatterns.InternationalPhone().IsMatch(number))
            throw new DomainException(
                $"{nameof(Phone)} must be a valid international phone number " +
                $"containing {MinLength}-{MaxLength} digits and include country code.");

        return new Phone(number);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}