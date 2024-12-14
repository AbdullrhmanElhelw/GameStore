namespace GameStore.Infrastructure.Infrastructure;

public sealed class ConnectionString(string value)
{
    public const string DefaultConnection = "DefaultConnection";
    public string Value { get; } = value;

    public static implicit operator string(ConnectionString connectionString) => connectionString.Value;

    public static implicit operator ConnectionString(string value) => new(value);
}