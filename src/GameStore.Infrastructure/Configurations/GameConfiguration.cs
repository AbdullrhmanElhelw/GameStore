using GameStore.Domain.Games;
using GameStore.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Infrastructure.Configurations;

internal sealed class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(game => game.Id);

        builder.Property(game => game.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(game => game.Description)
            .HasMaxLength(1000)
            .HasConversion(description => description.Value, value => new Description(value));

        builder.OwnsOne(game => game.Price, priceBuilder =>
        {
            priceBuilder.Property(price => price.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(game => game.ReleaseDate, releaseDateBuilder =>
        {
            releaseDateBuilder.Property(releaseDate => releaseDate.Value)
                .HasConversion<DateTime>();
        });
    }
}