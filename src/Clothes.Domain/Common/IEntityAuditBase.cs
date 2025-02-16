namespace MinimalApi.Domain.Commnon;

public interface IEntityAuditBase<TKey> : IEntityBase<TKey>, IUserTracking, IDatetimeTracking 
{
    
}