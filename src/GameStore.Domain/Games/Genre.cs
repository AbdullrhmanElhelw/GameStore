using GameStore.Domain.Utilities;

namespace GameStore.Domain.Games;

public record Genre
{
    public string Value { get; init; }

    public Genre(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Check.MaxLength(value, 50, nameof(value));
        Check.MinLength(value, 3, nameof(value));
        Value = value;
    }

    public static implicit operator string(Genre genre) => genre.Value;
    public static implicit operator Genre(string genre) => new(genre);
}