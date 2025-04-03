using BuildingBlock.Shared.Contracts.Domains.Interfaces;

namespace Shared.Contracts.Domains.Interfaces;

public interface IEntityAuditBase<TKey> : IEntityBase<TKey>, IUserTracking, IDatetimeTracking
{

}