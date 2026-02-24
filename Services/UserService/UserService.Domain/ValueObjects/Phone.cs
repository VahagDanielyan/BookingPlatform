using UserService.Domain.Common;
using UserService.Domain.Enums;
using UserService.Domain.Exceptions;

namespace UserService.Domain.ValueObjects;

public sealed class Phone : ValueObject
{
    private Phone(CountryCode countryCode, string number)
    {
        CountryCode = countryCode;
        Number = number;
    }

    public CountryCode CountryCode { get; }
    public string Number { get; }
    public string FullNumber => $"+{(int)CountryCode}{Number}";

    public override string ToString() => FullNumber;

    public static Phone Create(CountryCode countryCode, string number)
    {
        var normalizedNumber = RegexPatterns.NonDigitCharacters().Replace(number, "");

        if (string.IsNullOrWhiteSpace(number))
            throw new DomainException($"{nameof(Phone)} number cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(normalizedNumber))
            throw new DomainException($"{nameof(Phone)} number must contain digits only.");
        if (!CountryNumberLength.TryGetValue(countryCode, out var expectedLength))
            throw new DomainException($"Validation rules for country {countryCode} are not defined.");
        if (normalizedNumber.Length != expectedLength)
            throw new DomainException(
                $"Phone number length for {countryCode} must be exactly {expectedLength} digits.");

        return new Phone(countryCode, normalizedNumber);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return Number;
    }

    private static readonly Dictionary<CountryCode, int> CountryNumberLength =
        new()
        {
            { CountryCode.Armenia, 8 },
            { CountryCode.Russia, 10 },
            { CountryCode.USA, 10 },
            { CountryCode.Germany, 10 },
            { CountryCode.France, 9 },
            { CountryCode.UK, 10 },
            { CountryCode.Georgia, 9 },
        };
}