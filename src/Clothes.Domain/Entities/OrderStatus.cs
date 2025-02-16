using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("OrderStatus")]
public class OrderStatus : EntityAuditBase<int>
{
    [Required]
    [Column("Type")]
    [StringLength(100)]
    public string? Type { get; set; }

    [Required]
    [Column("Display")]
    public bool Display { get; set; }

    [Column("Code")]
    [StringLength(100)]
    public string? Code { get; set; }

    [Required]
    [Column("OrderId")]
    public int OrderId { get; set; }

    public virtual ICollection<Payment>? Payments { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}