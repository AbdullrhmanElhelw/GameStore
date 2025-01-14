using GameStore.Domain.Games;

namespace GameStore.Infrastructure.Repositories;

public class GameRepository(ApplicationDbContext dbContext) : Repository<Game>(dbContext), IGameRepository
{
}