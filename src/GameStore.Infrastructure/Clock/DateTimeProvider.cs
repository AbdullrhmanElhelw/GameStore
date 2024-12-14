using GameStore.Application.Abstractions.Clock;

namespace GameStore.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}