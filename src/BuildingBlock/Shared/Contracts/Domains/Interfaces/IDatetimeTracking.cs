namespace BuildingBlock.Shared.Contracts.Domains.Interfaces;

public interface IDatetimeTracking
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset LastModifiedDate { get; set; }
}