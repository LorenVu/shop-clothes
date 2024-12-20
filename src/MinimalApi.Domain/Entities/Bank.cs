using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Entities;

[Table("Banks")]
public class Bank : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string NameEn { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Code { get; set; }

    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
    
    //Relationship
    public ICollection<Partner> Partners { get; set; } = null!;
}