using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Utilities;

public static class Check
{
    public static void NotNull<T>(T value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }
    }

    public static void NotEmpty(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{name} cannot be empty.");
        }
    }

    public static void Email(string value, string name)
    {
        if (!new EmailAddressAttribute().IsValid(value))
        {
            throw new ArgumentException($"{name} is not a valid email address.");
        }
    }

    public static void MaxLength(string value, int length, string name)
    {
        if (value.Length > length)
        {
            throw new ArgumentException($"{name} cannot be longer than {length} characters.");
        }
    }

    public static void MinLength(string value, int length, string name)
    {
        if (value.Length < length)
        {
            throw new ArgumentException($"{name} cannot be shorter than {length} characters.");
        }
    }

    public static void NotDefault<T>(T value, string name)
    {
        if (value.Equals(default(T)))
        {
            throw new ArgumentException($"{name} cannot be the default value.");
        }
    }

    public static void NotFuture(DateTime value, string name)
    {
        if (value > DateTime.UtcNow)
        {
            throw new ArgumentException($"{name} cannot be in the future.");
        }
    }
}