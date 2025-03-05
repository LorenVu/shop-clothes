using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;

namespace Clothes.Domain.Entities;

[Table("brands")]
public class Brand : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string? Name { get; set; }

    [Column("code", TypeName = "varchar(100)")]
    public string? Code { get; set; }
    
    [Column("status", TypeName = "int4")]
    public int Status { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}