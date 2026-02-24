using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.ValueObjects;

public sealed class PasswordHash : ValueObject
{
    private PasswordHash(string value) => Value = value;

    public string Value { get; }

    public static PasswordHash Create(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new DomainException($"{nameof(PasswordHash)} cannot be null or empty.");

        return new PasswordHash(hash);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}