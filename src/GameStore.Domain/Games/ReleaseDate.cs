using GameStore.Domain.Utilities;

namespace GameStore.Domain.Games;

public record ReleaseDate
{
    public ReleaseDate(DateTime value)
    {
        Check.NotNull(value, nameof(value));
        Check.NotDefault(value, nameof(value));
        Check.NotFuture(value, nameof(value));
        Value = value;
    }

    public DateTime Value { get; init; }

    public static implicit operator DateTime(ReleaseDate releaseDate)
    {
        return releaseDate.Value;
    }

    public static implicit operator ReleaseDate(DateTime releaseDate)
    {
        return new ReleaseDate(releaseDate);
    }

    public bool NotInFuture() => Value <= DateTime.UtcNow.Date;
}