namespace Clothes.Domain.Common;

public interface IEntityAuditBase<TKey> : IEntityBase<TKey>, IUserTracking, IDatetimeTracking
{

}