using GameStore.Application.Abstractions.Caching;
using GameStore.Domain.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace GameStore.Infrastructure.Caching;

public class Cache<T>(IMemoryCache memoryCache) : ICache<T> where T : Entity
{
    public static string CacheKey { get; } = typeof(T).Name;
    public static TimeSpan CacheDuration { get; } = TimeSpan.FromMinutes(5);
    public static TimeSpan AbsoluteExpiration { get; } = TimeSpan.FromMinutes(10);

    public Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return memoryCache
            .GetOrCreateAsync($"{CacheKey}-{id}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = AbsoluteExpiration;
                entry.SlidingExpiration = CacheDuration;
                return Task.FromResult<T?>(null);
            });
    }

    public Task<bool> IsCachedAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(memoryCache.TryGetValue($"{CacheKey}-{id}", out _));
    }

    public Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        memoryCache.Remove($"{CacheKey}-{id}");
        return Task.CompletedTask;
    }

    public Task SetAsync(T entity, CancellationToken cancellationToken = default)
    {
        memoryCache.Set($"{CacheKey}-{entity.Id}", entity, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = AbsoluteExpiration,
            SlidingExpiration = CacheDuration
        });
        return Task.CompletedTask;
    }
}