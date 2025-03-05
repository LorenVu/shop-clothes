using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;

[Table("provinces")]
public class Province : EntityAuditBase<int>
{
    [Required]
    [Column("code", TypeName = "varchar(30)")]
    public string Code { get; init; }

    [Required]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; init; }

    [Column("name_en", TypeName = "varchar(100)")]
    public string NameEn { get; init; }

    [Column("active_flg")]
    public int ActiveFlg { get; init; }

    //Relationship
    [Column("country_id")]
    public int CountryId { get; set; }
    public Country Country { get; init; }

    public ICollection<District>? Districts { get; init; }
}