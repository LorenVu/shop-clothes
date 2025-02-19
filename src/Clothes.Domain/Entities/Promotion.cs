using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("Promotions")]
public class Promotion : EntityAuditBase<int>
{
    [Column("Code")]
    [MaxLength(100)]
    public string? Code { get; set; }

    [Column("DiscountPercent")]
    public double DiscountPercent { get; set; }
}