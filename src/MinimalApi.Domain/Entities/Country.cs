using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Countries")]
public class Country : EntityAuditBase<int>
{
    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Code { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string NameEn { get; set; }
    
    [Required]
    public int ActiveFLG { get; set; }
    
    //Relationship
    public ICollection<Province> Province { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = null!;
}