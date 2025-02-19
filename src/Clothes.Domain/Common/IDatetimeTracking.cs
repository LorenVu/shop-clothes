namespace Clothes.Domain.Common;

public interface IDatetimeTracking
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset LastModifiredDate { get; set; }
}