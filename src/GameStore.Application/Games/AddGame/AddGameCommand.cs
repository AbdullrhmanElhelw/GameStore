using GameStore.Domain.Games;
using GameStore.Domain.Shared;

namespace GameStore.Application.Games.AddGame;

public sealed record AddGameCommand
{
    public string Name { get; init; }
    public string? Description { get; init; }

    public string Price { get; init; }
    public Currency Currency { get; init; }

    public ReleaseDate ReleaseDate { get; init; }
}