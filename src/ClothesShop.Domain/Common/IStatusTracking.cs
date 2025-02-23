namespace Clothes.Domain.Common;

public interface IStatusTracking
{
    public int Status { get; set; }
    public bool IsDeleted { get; set; }
}