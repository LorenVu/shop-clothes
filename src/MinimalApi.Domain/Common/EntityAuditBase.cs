using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Domain.Commnon;

public abstract class EntityAuditBase<TKey> : EntityBase<TKey>, IEntityAuditBase<TKey>
{
    [Column(TypeName = "character(25)")]
    public string? CreatedUser { get; set; }
    [Column(TypeName = "character(25)")]
    public string? LastModifiedUser { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiredDate { get; set; }
}