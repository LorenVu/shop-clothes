using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("ProductImages")]
public class ProductImage : EntityAuditBase<int>
{
    [Required]
    [Column("OriginLinkImage")]
    [MaxLength(2000)]
    public string? OriginLinkImage { get; set; }

    [Column("LocalLinkImage")]
    [MaxLength(2000)]
    public string? LocalLinkImage { get; set; }

    [Required]
    [Column("ProductId")]
    public long ProductId { get; set; }

    public virtual Product? Product { get; set; }
}