using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("Banks")]
public class Bank : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; private set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string NameEn { get; private set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Code { get; private set; }

    [Required]
    [Column(TypeName = "varchar(11)")]
    public string SwiftCode { get; private set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Balance { get; private set; }


    [Column("is_active", TypeName = "byte")]
    public int IsActive { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    //Relationship
    public ICollection<Transaction> Transactions { get; init; }
}