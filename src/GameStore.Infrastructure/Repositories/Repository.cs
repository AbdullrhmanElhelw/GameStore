using GameStore.Domain.Abstractions;
using GameStore.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext) : IRepository<TEntity>
    where TEntity : Entity
{
    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
    }

    public async Task<IReadOnlyCollection<TEntity>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(dbContext.Set<TEntity>().Update(entity));
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(dbContext.Set<TEntity>().Remove(entity));
    }

    public Task<IQueryable<TEntity?>> ListAsync(ISpecification<TEntity> spec,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(ApplySpecification(spec).AsQueryable());
    }

    public async Task<TEntity?> GetEntityWithSpecAsync(ISpecification<TEntity> spec,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
    }

    public Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default)
    {
        return ApplySpecification(spec).CountAsync(cancellationToken);
    }

    private IQueryable<TEntity?> ApplySpecification(ISpecification<TEntity> spec)
    {
        return SpecificationEvaluator<TEntity>.GetQuery(dbContext.Set<TEntity>().AsQueryable(), spec);
    }
}