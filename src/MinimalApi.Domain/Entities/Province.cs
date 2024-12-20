using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Entities;

[Table("Provinces")]
public class Province : EntityAuditBase<int>
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
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public ICollection<District> Districts { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = null!;
}