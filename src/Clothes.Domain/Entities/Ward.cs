using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("Wards")]
public class Ward : EntityAuditBase<int>
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
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = null!;
}