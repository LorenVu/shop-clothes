using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

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
    [Column("user_id")]
    public Guid UserId { get; init; }
    
    [Column("is_active", TypeName = "int4")]
    public int IsActive { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public virtual Payment? Payments { get; init; }

    public virtual ICollection<OrderItem>? Items { get; init; }
    public virtual OrderStatus? OrderStatus { get; set; }

    public void ModifyStatus(int statusId)
    {
        this.StatusId = statusId;
    }
}