using GameStore.Domain.Abstractions;
using GameStore.Domain.Developers;
using GameStore.Domain.Games;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Developer> Developers => Set<Developer>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        await PublishDomainEventAsync();
        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    private async Task PublishDomainEventAsync()
    {
        var domainEntities = ChangeTracker
            .Entries<Entity>()
            .Select(entity => entity.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEntities) await mediator.Publish(domainEvent);
    }
}