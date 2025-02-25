namespace BuildingBlock.Shared.Contracts.Domains.Interfaces;

public interface IUserTracking
{
    public string? CreatedUser { get; set; }
    public string? LastModifiedUser { get; set; }
}