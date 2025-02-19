namespace Clothes.Domain.Common;

public interface IStatusTracking
{
    public int IsActive { get; set; }
    public bool IsDeleted { get; set; }
}