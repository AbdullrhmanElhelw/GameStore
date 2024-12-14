using GameStore.Domain.Utilities;

namespace GameStore.Domain.Developers;

public record Website
{
    public string Value { get; init; }

    public Website(string value)
    {
        Check.NotNull(value, "value");
        Value = value;
    }

    public static implicit operator string(Website website) => website.Value;

    public static implicit operator Website(string value) => new(value);
}