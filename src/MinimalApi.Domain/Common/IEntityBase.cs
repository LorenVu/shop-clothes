namespace MinimalApi.Domain.Commnon;

public interface IEntityBase<TKey>
{
    public TKey Id { get; set; }
}