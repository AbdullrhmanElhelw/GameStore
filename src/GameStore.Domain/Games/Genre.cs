using GameStore.Domain.Utilities;

namespace GameStore.Domain.Games;

public record Genre
{
    public Genre(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Check.MaxLength(value, 50, nameof(value));
        Check.MinLength(value, 3, nameof(value));
        Value = value;
    }

    public string Value { get; init; }

    public static implicit operator string(Genre genre)
    {
        return genre.Value;
    }

    public static implicit operator Genre(string genre)
    {
        return new Genre(genre);
    }
}