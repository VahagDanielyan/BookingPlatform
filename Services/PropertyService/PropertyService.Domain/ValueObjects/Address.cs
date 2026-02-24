using PropertyService.Domain.Enums;
using PropertyService.Domain.Exceptions;

namespace PropertyService.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    private const int StreetMinLength = 3;
    private const int StreetMaxLength = 100;

    private Address(Country country, City city, string street)
    {
        Country = country;
        City = city;
        Street = street;
    }

    public Country Country { get; }
    public City City { get; }
    public string Street { get; }

    public static Address Create(Country country, City city, string street)
    {
        if (GetCountry(city) != country)
            throw new DomainException($"{nameof(City)} does not belong to the specified {nameof(Country)}.");
        if (street.Length > StreetMaxLength)
            throw new DomainException($"{nameof(street)} cannot exceed {StreetMaxLength} characters.");
        if (street.Length < StreetMinLength)
            throw new DomainException($"{nameof(street)} must contain at least {StreetMinLength} characters.");

        return new Address(country, city, street);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return City;
        yield return Street;
    }

    private static Country GetCountry(City city)
    {
        var prefix = city.ToString().Split('_')[0];

        return prefix switch
        {
            "US" => Country.USA,
            "DE" => Country.Germany,
            "FR" => Country.France,
            "UK" => Country.UK,
            "RU" => Country.Russia,
            "AM" => Country.Armenia,
            "GE" => Country.Georgia,
            _ => throw new DomainException($"Not supported {nameof(Country)}.")
        };
    }
}