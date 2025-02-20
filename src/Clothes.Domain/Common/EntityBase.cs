using System.ComponentModel.DataAnnotations.Schema;

namespace Clothes.Domain.Common;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    [Column("id")]
    public required TKey Id { get; set; }
}