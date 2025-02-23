namespace Clothes.Domain.Common;

public interface IUserTracking
{
    public string? CreatedUser { get; set; }
    public string? LastModifiedUser { get; set; }
}