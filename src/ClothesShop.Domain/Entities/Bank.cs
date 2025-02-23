using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("banks")]
public class Bank : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; private set; }

    [Required]
    [Column("name_en", TypeName = "varchar(100)")]
    public string NameEn { get; private set; }

    [Required]
    [Column("code", TypeName = "varchar(50)")]
    public string Code { get; private set; }

    [Required]
    [Column("swift_code",TypeName = "varchar(11)")]
    public string SwiftCode { get; private set; }

    [Required]
    [Column("balance", TypeName = "decimal(18,2)")]
    public decimal Balance { get; private set; }
    
    [Column("status", TypeName = "int4")]
    public int Status { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    //Relationship
    public ICollection<SepayTransaction>? Transactions { get; init; }
}