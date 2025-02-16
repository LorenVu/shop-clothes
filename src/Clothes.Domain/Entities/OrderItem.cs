using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("OrderItems")]
public class OrderItem : EntityAuditBase<int>
{
    [Required]
    [Column("Quantity")]
    public int Quantity { get; set; }

    [Required]
    [Column("Price")]
    public double Price { get; set; }

    [Required]
    [Column("OrderId")]
    public long OrderId { get; set; }

    [Required]
    [Column("ProductId")]
    public long ProductId { get; set; }

    [Required]
    [Column("PromotionId")]
    public int PromotionId { get; set; }

    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Promotion? Promotion { get; set; }
}