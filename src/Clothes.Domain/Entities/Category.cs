using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("categories")]
public class Category : EntityAuditBase<long>, IStatusTracking
{
    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string? Name { get; set; }

    [Column("code", TypeName = "varchar(100)")]
    public string? Code { get; set; }

    [Column("url", TypeName = "varchar(150)")]
    public string? Url { get; set; }

    [Column("icon", TypeName = "varchar(150)")]
    public string? Icon { get; set; }

    [Column("parent_id")]
    public int ParentId { get; set; }

    [Column("sort_order")]
    public int SortOrder { get; set; }
    
    [Column("is_active", TypeName = "int4")]
    public int IsActive { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}