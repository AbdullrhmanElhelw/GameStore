using GameStore.Domain.Utilities;

namespace GameStore.Domain.Developers;

public record Headquarters
{
    public Country Country { get; init; }
    public City City { get; init; }
    public Street Street { get; init; }
    public ZipCode ZipCode { get; init; }

    public Headquarters(Country country, City city, Street street, ZipCode zipCode)
    {
        Check.NotNull(country, "country");
        Check.NotNull(city, "city");
        Check.NotNull(street, "street");
        Check.NotNull(zipCode, "zipCode");
        Country = country;
        City = city;
        Street = street;
        ZipCode = zipCode;
    }
}

public record Country
{
    public string Value { get; init; }

    public Country(string value)
    {
        Check.NotNull(value, "value");
        Check.MaxLength(value, 100, "value");
        Value = value;
    }
}

public record City
{
    public string Value { get; init; }

    public City(string value)
    {
        Check.NotNull(value, "value");
        Check.MaxLength(value, 100, "value");
        Value = value;
    }
}

public record Street
{
    public string Value { get; init; }

    public Street(string value)
    {
        Check.NotNull(value, "value");
        Check.MaxLength(value, 100, "value");
        Value = value;
    }
}

public record ZipCode
{
    public string Value { get; init; }

    public ZipCode(string value)
    {
        Check.NotNull(value, "value");
        Check.MaxLength(value, 20, "value");
        Value = value;
    }
}

/*
 *builder.OwnsOne(developer => developer.Headquarters, headquartersBuilder =>
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
 */