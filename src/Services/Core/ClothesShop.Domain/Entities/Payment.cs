using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Shared.Contracts.Domains;

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

    [Column("status", TypeName = "int4")]
    public int Status { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public int OrderId { get; set; }
    public virtual Order? Orders { get; init; }
}