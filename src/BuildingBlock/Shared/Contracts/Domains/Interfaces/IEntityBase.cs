namespace BuildingBlock.Shared.Contracts.Domains.Interfaces;

public interface IEntityBase<TKey>
{
    public TKey Id { get; set; }
}