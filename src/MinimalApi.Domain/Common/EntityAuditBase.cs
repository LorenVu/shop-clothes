using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Common;

public abstract class EntityAuditBase<TKey> : EntityBase<TKey>, IEntityAuditBase<TKey>
{
    [Column(TypeName = "character(25)")]
    public string? CreatedUser { get; set; }
    [Column(TypeName = "character(25)")]
    public string? LastModifiedUser { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset LastModifiredDate { get; set; } = DateTimeOffset.Now;
}