using System.ComponentModel.DataAnnotations.Schema;

namespace Clothes.Domain.Common;

public abstract class EntityAuditBase<TKey> : EntityBase<TKey>, IEntityAuditBase<TKey>
{
    [Column("created_user", TypeName = "varchar(25)")]
    public string? CreatedUser { get; set; }
    
    [Column("last_modified_user", TypeName = "varchar(25)")]
    public string? LastModifiedUser { get; set; }
    
    [Column("created_date")]
    public DateTimeOffset CreatedDate { get; set; }
    
    [Column("last_modified_date")]
    public DateTimeOffset LastModifiedDate { get; set; }
}