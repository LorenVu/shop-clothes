using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;
#nullable disable


[Table("districts")]
public class District : EntityAuditBase<int>
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
    [Column("province_id")]
    public int ProvinceId { get; init; }
    public Province Province { get; init; }

    public ICollection<Ward> Wards { get; init; }
    public ICollection<Address> Addresses { get; init; }
}