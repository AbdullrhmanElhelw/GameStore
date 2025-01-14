using GameStore.Domain.Abstractions;
using GameStore.Domain.Developers;
using GameStore.Domain.Shared;

namespace GameStore.Domain.Games;

public sealed class Game : Entity
{
    private Game(
        Name name,
        Description description,
        Money price,
        ReleaseDate releaseDate,
        Developer developer
    )
    {
        Name = name;
        Description = description;
        Price = price;
        ReleaseDate = releaseDate;
        Developer = developer;
    }

    private Game()
    {
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Money Price { get; private set; }
    public ReleaseDate ReleaseDate { get; private set; }

    public Guid DeveloperId { get; private set; }
    public Developer Developer { get; private set; }

    public static Game CreateGame(
        Name name,
        Description description,
        Money price,
        ReleaseDate releaseDate,
        Developer developer
    )
    {
        return new Game(name, description, price, releaseDate, developer);
    }
}