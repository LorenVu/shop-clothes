using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;

namespace BuildingBlock.Shared.Contracts.Domains;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    [Column("id")]
    public TKey Id { get; set; }
}