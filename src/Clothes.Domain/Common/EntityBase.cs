namespace Clothes.Domain.Common;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    public required TKey Id { get; set; }
}