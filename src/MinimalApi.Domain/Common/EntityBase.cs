namespace MinimalApi.Domain.Commnon;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    public required TKey Id { get; set; }
}