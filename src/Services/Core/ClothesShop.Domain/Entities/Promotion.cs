using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;

[Table("promotions")]
public class Promotion : EntityAuditBase<int>
{
    [Column("code", TypeName = "varchar(100)")]
    public string? Code { get; init; }

    [Column("discount_percent")]
    public double DiscountPercent { get; init; }
}