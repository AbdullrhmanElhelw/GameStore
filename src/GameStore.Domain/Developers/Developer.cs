using GameStore.Domain.Abstractions;
using GameStore.Domain.Games;
using GameStore.Domain.Shared;

namespace GameStore.Domain.Developers;

public sealed class Developer : Entity
{
    private readonly HashSet<Game> _games = [];

    private Developer(
        Name name,
        DateTime founded,
        Description? description,
        Email contactEmail,
        Headquarters headquarters,
        Website? website = null
        )
    {
        Name = name;
        Founded = founded;
        Description = description;
        ContactEmail = contactEmail;
        Headquarters = headquarters;
        Website = website;
    }

    private Developer()
    { }

    public Name Name { get; private set; }

    public DateTime Founded { get; private set; }

    public Description? Description { get; private set; }

    public Email ContactEmail { get; private set; }

    public Headquarters Headquarters { get; private set; }

    public Website? Website { get; private set; }

    public IReadOnlyCollection<Game> Games => _games;

    public static Developer CreateDeveloper(
        Name name,
        DateTime founded,
        Description? description,
        Email contactEmail,
        Headquarters headquarters,
        Website? website = null
        )
    {
        return new Developer(name, founded, description, contactEmail, headquarters, website);
    }
}