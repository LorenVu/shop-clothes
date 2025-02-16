using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Products")]
public class Product : EntityAuditBase<long>, IStatusTracking
{
    [Required]
    [Column("Name")]
    [MaxLength(150)]
    public string Name { get; set; }

    [Column("Code")]
    [MaxLength(100)]
    public string? Code { get; set; }

    [MaxLength(2000)]
    [Column("Description")]
    public string? Description { get; set; }

    [Required]
    [Column("Prize")]
    public double Prize { get; set; }

    [Column("Discount")]
    public double Discount { get; set; }

    [Required]
    [Column("Currency")]
    [MaxLength(100)]
    public string? Currency { get; set; }

    [Required]
    [Column("DefaultImage")]
    public string? DefaultImage { get; set; }

    [Column("OriginLinkDetail")]
    public string? OriginLinkDetail { get; set; }

    [Column("Url")]
    public string? Url { get; set; }

    [Required]
    [Column("Stock")]
    public bool Stock { get; set; }
    
    [Column("IsActive")]
    public int IsActive { get; set; }
    
    [Column("IsDeleted")]
    public int IsDeleted { get; set; }

    [Required]
    [Column("CategoryId")]
    public int CategoryId { get; set; }

    [Required]
    [Column("BrandId")]
    public int BrandId { get; set; }
    
    public virtual Category? Categories { get; set; }

    public virtual Brand? Brands { get; set; }

    public virtual ICollection<Property>? Properties { get; set; } 
    public virtual ICollection<ProductImage>? ProductImages { get; set; }
    public virtual ICollection<OrderItem>? Items { get; set; }

}