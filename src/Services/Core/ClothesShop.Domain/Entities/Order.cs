using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;

[Table("orders")]
public class Order : EntityAuditBase<long>, IStatusTracking
{
    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string? Name { get; init; }

    [Column("customer_name", TypeName = "varchar(100)")]
    public string? CustomerName { get; init; }

    [Required]
    [Column("address", TypeName = "varchar(100)")]
    public string? Address { get; init; }

    [Required]
    [Column("phone_number", TypeName = "varchar(12)")]
    public string? PhoneNumber { get; init; }

    [Required]
    [Column("total_amount", TypeName = "varchar(12)")]
    public double TotalAmount { get; init; }

    [Column("note", TypeName = "varchar(255)")]
    public string? Note { get; init; }

    [Column("cancel_reason", TypeName = "varchar(255)")]
    public string? CancelReason { get; init; }

    [Required]
    [Column("payment_id")]
    public int PaymentId { get; init; }

    [Column("status_id")]
    public int StatusId { get; private set; }

    [Required]
    [Column("customer_id")]
    public Guid? CustomerId { get; init; }
    
    [Column("status", TypeName = "int4")]
    public int Status { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("order_status_id")]
    public int OrderStatusId { get; set; }

    public virtual ICollection<Payment>? Payments { get; init; }
    public virtual ICollection<OrderItem>? Items { get; init; }
    public virtual OrderStatus? OrderStatus { get; init; }

    public void ModifyStatus(int statusId)
    {
        this.StatusId = statusId;
    }
}