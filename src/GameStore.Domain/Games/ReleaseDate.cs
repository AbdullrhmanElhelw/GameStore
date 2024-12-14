using GameStore.Domain.Utilities;

namespace GameStore.Domain.Games;

public record ReleaseDate
{
    public DateTime Value { get; init; }
    public ReleaseDate(DateTime value)
    {
        Check.NotNull(value, nameof(value));
        Check.NotDefault(value, nameof(value));
        Check.NotFuture(value, nameof(value));
        Value = value;
    }
    public static implicit operator DateTime(ReleaseDate releaseDate) => releaseDate.Value;
    public static implicit operator ReleaseDate(DateTime releaseDate) => new(releaseDate);
}