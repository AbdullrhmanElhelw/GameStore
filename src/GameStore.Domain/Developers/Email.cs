using GameStore.Domain.Utilities;

namespace GameStore.Domain.Developers;

public record Email
{
    public string Value { get; init; }
    public Email(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Check.Email(value, nameof(value));
        Value = value;
    }
    public static implicit operator string(Email email) => email.Value;
    public static implicit operator Email(string value) => new(value);
}