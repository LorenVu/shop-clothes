namespace BuildingBlock.Shared.Configs;

public class MongoDbSettings : DatabaseSettings
{
    public required string DatabaseName { get; init; }
}