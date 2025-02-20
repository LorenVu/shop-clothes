using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("payments")]
public class Payment : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column("amount")]
    public double Amount { get; set; }

    [Column("payment_method", TypeName = "varchar(50)")]
    public string? PaymentMethod { get; set; }

    [Required]
    [Column("transaction_id", TypeName = "varchar(100)")]
    public string? TransactionId { get; set; }

    [Column("payment_code", TypeName = "varchar(100)")]
    public string? PaymentCode { get; set; }

    [Required]
    [Column("transaction_date", TypeName = "timestamp")]
    public DateTime TransactionDate { get; set; }

    [Column("fee")]
    public double Fee { get; set; }

    [Required]
    [Column("status_id")]
    public int StatusId { get; set; }
    
    [Column("is_active", TypeName = "int4")]
    public int IsActive { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public virtual ICollection<Order>? Orders { get; init; }
}