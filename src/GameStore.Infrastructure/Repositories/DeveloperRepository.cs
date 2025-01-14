using GameStore.Domain.Developers;

namespace GameStore.Infrastructure.Repositories;

public class DeveloperRepository(ApplicationDbContext dbContext) : Repository<Developer>(dbContext), IDeveloperRepository
{
}