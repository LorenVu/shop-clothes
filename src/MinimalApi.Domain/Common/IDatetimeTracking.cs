namespace MinimalApi.Domain.Commnon;

public interface IDatetimeTracking
{
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiredDate { get; set; }
}