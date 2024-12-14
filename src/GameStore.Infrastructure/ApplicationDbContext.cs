using GameStore.Domain.Abstractions;
using GameStore.Domain.Developers;
using GameStore.Domain.Games;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Developer> Developers => Set<Developer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}