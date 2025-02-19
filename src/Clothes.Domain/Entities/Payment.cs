using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("Payments")]
public class Payment : EntityAuditBase<int>
{
    [Required]
    [Column("Amount")]
    public double Amount { get; set; }

    [Column("PaymentMethod")]
    public string? PaymentMethod { get; set; }

    [Column("TransactionId")]
    public string? TransactionId { get; set; }

    [Column("PaymentCode")]
    public string? PaymentCode { get; set; }

    [Required]
    [Column("TransactionDate")]
    public DateTime TransactionDate { get; set; }

    [Column("Fee")]
    public double Fee { get; set; }

    [Required]
    [Column("StatusId")]
    public int StatusId { get; set; }

    public virtual OrderStatus OrderStatus { get; set; }
}