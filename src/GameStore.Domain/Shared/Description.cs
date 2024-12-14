using GameStore.Domain.Utilities;

namespace GameStore.Domain.Shared;

public record Description
{
    public string Value { get; init; }
    public Description(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Value = value;
    }
    public static implicit operator string(Description description) => description.Value;
    public static implicit operator Description(string value) => new(value);
}