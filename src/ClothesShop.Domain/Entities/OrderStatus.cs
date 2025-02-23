using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("order_status")]
public class OrderStatus : EntityAuditBase<int>
{
    [Required]
    [Column("type", TypeName = "varchar(100)")]
    public string? Type { get; init; }

    [Required]
    [Column("display", TypeName = "varchar(100)")]
    public bool Display { get; init; }

    [Column("code", TypeName = "varchar(100)")]
    public string? Code { get; init; }

    public virtual ICollection<Order>? Orders { get; set; }
}