using GameStore.Application.Abstractions.Caching;
using GameStore.Domain.Abstractions;
using GameStore.Domain.Games;

namespace GameStore.Infrastructure.Caching.CachedRepositories;

public class GameCachedRepository(IGameRepository gameRepository, ICache<Game> cacheService) : IGameRepository
{
    public async Task AddAsync(Game entity, CancellationToken cancellationToken = default)
    {
        await gameRepository.AddAsync(entity, cancellationToken);
        await cacheService.SetAsync(entity, cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<Game> spec, CancellationToken cancellationToken = default)
    {
        return await gameRepository.CountAsync(spec, cancellationToken);
    }

    public async Task DeleteAsync(Game entity, CancellationToken cancellationToken = default)
    {
        await gameRepository.DeleteAsync(entity, cancellationToken);
        await cacheService.RemoveAsync(entity.Id, cancellationToken);
    }

    public async Task<Game?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cachedEntity = await cacheService.GetAsync(id, cancellationToken);
        if (cachedEntity != null)
            return cachedEntity;

        var entity = await gameRepository.GetByIdAsync(id, cancellationToken);
        if (entity != null)
            await cacheService.SetAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<Game?> GetEntityWithSpecAsync(ISpecification<Game> spec, CancellationToken cancellationToken = default)
    {
        // Spec-based caching could be implemented with a custom spec key if needed.
        return await gameRepository.GetEntityWithSpecAsync(spec, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Game>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await gameRepository.ListAllAsync(cancellationToken);
    }

    public async Task<IQueryable<Game?>> ListAsync(ISpecification<Game> spec, CancellationToken cancellationToken = default)
    {
        return await gameRepository.ListAsync(spec, cancellationToken);
    }

    public async Task UpdateAsync(Game entity, CancellationToken cancellationToken = default)
    {
        await gameRepository.UpdateAsync(entity, cancellationToken);
        await cacheService.SetAsync(entity, cancellationToken);
    }
}