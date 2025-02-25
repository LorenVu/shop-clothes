namespace BuildingBlock.Shared.Contracts.Domains.Interfaces;

public interface IStatusTracking
{
    public int Status { get; set; }
    public bool IsDeleted { get; set; }
}