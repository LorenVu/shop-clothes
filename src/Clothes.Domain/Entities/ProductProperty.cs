using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("product_properties")]
public class ProductProperty : EntityBase<int>, IStatusTracking
{
    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string? Name { get; set; }

    [Required]
    [Column("value", TypeName = "varchar(150)")]
    public string? Value { get; set; }

    [Required]
    [Column("product_id")]
    public long ProductId { get; set; }
    
    [Column("status", TypeName = "int4")]
    public int Status { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}