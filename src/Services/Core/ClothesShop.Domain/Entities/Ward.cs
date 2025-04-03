using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;

[Table("wards")]
public class Ward : EntityAuditBase<int>
{
    [Required]
    [Column("code", TypeName = "varchar(30)")]
    public string Code { get; init; }

    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; init; }

    [Required]
    [Column("name_en", TypeName = "varchar(100)")]
    public string NameEn { get; init; }

    [Required]
    [Column("active_flg")]
    public int ActiveFlg { get; init; }

    //Relationship
    [Column("district_id")]
    public int DistrictId { get; init; }
    public District? District { get; init; }
    
    public ICollection<Address>? Addresses { get; init; }
}