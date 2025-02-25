namespace BuildingBlock.Shared.Configs;

public class DatabaseSettings
{
    public required string DbProvider { get; init; }
    public required string ConnectionString { get; init; }
}