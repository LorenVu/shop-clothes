using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;

[Table("products")]
public class Product : EntityAuditBase<long>, IStatusTracking
{
    [Required]
    [Column("name", TypeName = "varchar(150)")]
    public required string Name { get; init; }
    
    [Required]
    [Column("no", TypeName = "varchar(150)")]
    public required string No { get; init; }

    [Column("code", TypeName = "varchar(100)")]
    public string? Code { get; init; }

    [Column("description", TypeName = "varchar(2000)")]
    public string? Description { get; init; }
    
    [Column("summary", TypeName = "varchar(2000)")]
    public string? Summary { get; init; }

    [Required]
    [Column("price", TypeName = "decimal(18,2)")]
    public decimal Price { get; init; }

    [Column("discount")]
    public double Discount { get; init; }

    [Required]
    [Column("currency", TypeName = "varchar(100)")]
    public string? Currency { get; init; }

    [Required]
    [Column("default_image", TypeName = "varchar(1000)")]
    public string? DefaultImage { get; init; }

    [Column("origin_link_detail", TypeName = "varchar(500)")]
    public string? OriginLinkDetail { get; init; }

    [Column("url", TypeName = "varchar(500)")]
    public string? Url { get; init; }

    [Required]
    [Column("stock")]
    public bool Stock { get; init; }

    [Column("status", TypeName = "int4")]
    public int Status { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Required]
    [Column("category_id")]
    public long CategoryId { get; private set; }

    [Required]
    [Column("brand_id")]
    public int BrandId { get; private set; }

    public virtual Category? Categories { get; init; }

    public virtual Brand? Brands { get; init; }

    public virtual ICollection<ProductProperty>? Properties { get; init; }
    public virtual ICollection<ProductImage>? ProductImages { get; init; }
    public virtual ICollection<OrderItem>? Items { get; init; }

    public Product ModifyBrand(int brandId)
    {
        this.BrandId = brandId;
        return this;
    }

    public Product ModifyCategory(int categoryId)
    {
        this.CategoryId = categoryId;
        return this;
    }
}