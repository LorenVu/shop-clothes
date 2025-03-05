using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;

[Table("order_items")]
public class OrderItem : EntityAuditBase<int>
{
    [Required]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Required]
    [Column("price")]
    public double Price { get; set; }

    [Required]
    [Column("order_id")]
    public long OrderId { get; set; }

    [Required]
    [Column("product_id")]
    public long ProductId { get; set; }

    [Required]
    [Column("promotion_id")]
    public int PromotionId { get; set; }

    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Promotion? Promotion { get; set; }
}