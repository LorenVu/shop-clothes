using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("product_images")]
public class ProductImage : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column("origin_link_image", TypeName = "varchar(2000)")]
    public string? OriginLinkImage { get; init; }

    [Column("local_link_image", TypeName = "varchar(2000)")]
    public string? LocalLinkImage { get; init; }

    [Required]
    [Column("product_id")]
    public long ProductId { get; init; }
    
    [Column("status", TypeName = "int4")]
    public int Status { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public virtual Product? Product { get; init; }
}