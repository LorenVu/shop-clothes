using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using BuildingBlock.Shared.Enums.Common;

namespace Clothes.Domain.Entities;

[Table("categories")]
public class Category(string name, string code, string icon, int parentId, int sortOrder) : EntityAuditBase<long>, IStatusTracking
{
    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; private set; } = name;

    [Column("code", TypeName = "varchar(100)")]
    public string Code { get; private set; } = code;

    [Column("icon", TypeName = "varchar(150)")]
    public string? Icon { get; private set; } = icon;

    [Column("parent_id")] 
    public int ParentId { get; private set; } = parentId;

    [Column("sort_order")] 
    public int SortOrder { get; private set; } = sortOrder;
    
    [Column("status", TypeName = "int4")]
    public int Status { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

    public void SetStatus(EStatusBase status)
        => this.Status = (int)status;
    
    public void SetIsDeleted(bool delete)
        => this.IsDeleted = delete;
}