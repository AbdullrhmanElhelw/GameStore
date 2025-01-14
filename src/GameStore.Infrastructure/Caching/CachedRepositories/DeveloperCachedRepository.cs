using GameStore.Application.Abstractions.Caching;
using GameStore.Domain.Abstractions;
using GameStore.Domain.Developers;

namespace GameStore.Infrastructure.Caching.CachedRepositories;

public class DeveloperCachedRepository(
    IDeveloperRepository developerRepository,
    ICache<Developer> cacheService
    ) : IDeveloperRepository
{
    public async Task AddAsync(Developer entity, CancellationToken cancellationToken = default)
    {
        await developerRepository.AddAsync(entity, cancellationToken);
        await cacheService.SetAsync(entity, cancellationToken);
    }

    public Task<int> CountAsync(ISpecification<Developer> spec, CancellationToken cancellationToken = default)
    {
        return developerRepository.CountAsync(spec, cancellationToken);
    }

    public async Task DeleteAsync(Developer entity, CancellationToken cancellationToken = default)
    {
        await developerRepository.DeleteAsync(entity, cancellationToken);
        await cacheService.RemoveAsync(entity.Id, cancellationToken);
    }

    public async Task<Developer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cachedEntity = await cacheService.GetAsync(id, cancellationToken);
        if (cachedEntity != null)
            return cachedEntity;

        var entity = await developerRepository.GetByIdAsync(id, cancellationToken);
        if (entity != null)
            await cacheService.SetAsync(entity, cancellationToken);

        return entity;
    }

    public Task<Developer?> GetEntityWithSpecAsync(ISpecification<Developer> spec, CancellationToken cancellationToken = default)
    {
        return developerRepository.GetEntityWithSpecAsync(spec, cancellationToken);
    }

    public Task<IReadOnlyCollection<Developer>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return developerRepository.ListAllAsync(cancellationToken);
    }

    public Task<IQueryable<Developer?>> ListAsync(ISpecification<Developer> spec, CancellationToken cancellationToken = default)
    {
        return developerRepository.ListAsync(spec, cancellationToken);
    }

    public async Task UpdateAsync(Developer entity, CancellationToken cancellationToken = default)
    {
        await developerRepository.UpdateAsync(entity, cancellationToken);
        await cacheService.SetAsync(entity, cancellationToken);
    }
}