using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Promotions")]
public class Promotion : EntityAuditBase<int>
{
    [Column("Code")]
    [MaxLength(100)]
    public string? Code { get; set; }

    [Column("DiscountPercent")]
    public double DiscountPercent { get; set; }
}