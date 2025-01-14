using GameStore.Domain.Utilities;

namespace GameStore.Domain.Games;

public record Title
{
    public Title(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Check.MaxLength(value, 100, nameof(value));
        Check.MinLength(value, 3, nameof(value));
        Value = value;
    }

    public string Value { get; init; }

    public static implicit operator string(Title title)
    {
        return title.Value;
    }

    public static implicit operator Title(string title)
    {
        return new Title(title);
    }
}