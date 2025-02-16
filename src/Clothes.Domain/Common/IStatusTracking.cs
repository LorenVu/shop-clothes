namespace MinimalApi.Domain.Commnon;

public interface IStatusTracking
{
    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
}