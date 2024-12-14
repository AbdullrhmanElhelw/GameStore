namespace GameStore.Domain.Abstractions;

public interface IRepository<TEntity>
 where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TEntity>> ListAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<IQueryable<TEntity?>> ListAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);

    Task<TEntity?> GetEntityWithSpecAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);

    Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
}