using GameStore.Domain.Developers;
using GameStore.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Infrastructure.Configurations;

internal sealed class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.HasKey(developer => developer.Id);
        builder.Property(developer => developer.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, name => new Name(name));

        builder.Property(developer => developer.Founded)
            .IsRequired();

        builder.Property(developer => developer.Website)
            .HasConversion(website => website.Value, website => new Website(website));

        builder.Property(developer => developer.Description)
            .HasMaxLength(1000)
            .HasConversion(description => description.Value, description => new Description(description));

        builder.Property(developer => developer.ContactEmail)
            .HasConversion(email => email.Value, email => new Email(email));

        builder.OwnsOne(developer => developer.Headquarters, headquartersBuilder =>
            {
                headquartersBuilder.Property(headquarters => headquarters.Country)
                    .HasMaxLength(100)
                    .HasConversion(country => country.Value, country => new Country(country));
                headquartersBuilder.Property(headquarters => headquarters.City)
                    .HasMaxLength(100)
                    .HasConversion(city => city.Value, city => new City(city));
                headquartersBuilder.Property(headquarters => headquarters.Street)
                    .HasMaxLength(100)
                    .HasConversion(street => street.Value, street => new Street(street));
                headquartersBuilder.Property(headquarters => headquarters.ZipCode)
                    .HasMaxLength(20)
                    .HasConversion(zipCode => zipCode.Value, zipCode => new ZipCode(zipCode));
            });

        builder.HasMany(developer => developer.Games)
            .WithOne(game => game.Developer)
            .HasForeignKey(game => game.DeveloperId);
    }
}