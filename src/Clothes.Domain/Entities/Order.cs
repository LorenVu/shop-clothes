using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("Orders")]
public class Order : EntityAuditBase<long>
{
    [Required]
    [Column("Name")]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Column("CustomerName")]
    [MaxLength(100)]
    public string? CustomerName { get; set; }

    [Column("Address")]
    [MaxLength(100)]
    public string? Address { get; set; }

    [Column("PhoneNumber")]
    [MaxLength(12)]
    public string? PhoneNumber { get; set; }

    [Required]
    [Column("TotalAmount")]
    public double TotalAmount { get; set; }

    [Column("Note")]
    public string? Note { get; set; }

    [Column("CancelReason")]
    public string? CancelReason { get; set; }

    [Required]
    [Column("PaymentId")]
    public int PaymentId { get; set; }

    [Column("StatusId")]
    public int StatusId { get; set; }

    [Required]
    [Column("UserId")]
    public Guid UserId { get; set; }

    public virtual ICollection<Payment>? Payments { get; set; }

    public virtual ICollection<OrderItem>? Items { get; set; }
}