namespace GameStore.Application.Abstractions.Seeder;

public interface IDataSeeder
{
    /// <summary>
    /// Seeds initial data into the system.
    /// </summary>
    Task SeedAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears all seeded data.
    /// </summary>
    Task ClearAsync(CancellationToken cancellationToken = default);
}