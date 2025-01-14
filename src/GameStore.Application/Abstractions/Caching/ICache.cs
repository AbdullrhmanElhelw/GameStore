using GameStore.Domain.Abstractions;

namespace GameStore.Application.Abstractions.Caching;

public interface ICache<T> where T : Entity
{
    static string CacheKey { get; } = typeof(T).Name;
    static TimeSpan CacheDuration { get; } = TimeSpan.FromMinutes(5);
    static TimeSpan AbsoluteExpiration { get; } = TimeSpan.FromMinutes(10);

    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task SetAsync(T entity, CancellationToken cancellationToken = default);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsCachedAsync(Guid id, CancellationToken cancellationToken = default);
}