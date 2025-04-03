using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Shared.Contracts.Domains.Interfaces;

namespace Shared.Contracts.Domains;

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