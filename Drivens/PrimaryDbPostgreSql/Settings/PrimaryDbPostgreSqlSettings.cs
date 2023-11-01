namespace PrimaryDbPostgreSql.Settings;

public record PrimaryDbPostgreSqlSettings
{
    public required string ConnectionStr { get; init; }
}