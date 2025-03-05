using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;
#nullable disable

[Table("countries")]
public class Country : EntityAuditBase<int>
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
    public ICollection<Province> Provinces { get; init; }
    public ICollection<Address> Address { get; init; }
}