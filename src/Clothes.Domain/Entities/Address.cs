using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("address")]
public class Address : EntityAuditBase<int>, IStatusTracking
{
    public Address(string addresses, string addressType, string postalCode)
    {
        Addresses = addresses;
        AddressType = addressType;
        PostalCode = postalCode;
    }

    [Required]
    [Column("addresses", TypeName = "varchar(255)")]
    public string Addresses { get; private set; }

    [Required]
    [Column("address_type", TypeName = "varchar(15)")]
    public string AddressType { get; private set; }

    [Column("postal_code", TypeName = "varchar(255)")]
    public string PostalCode { get; private set; }

    [Column("status", TypeName = "int4")]
    public int Status { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    //RelationShip
    [Column("country_id")]
    public int CountryId { get; set; }

    public Country Country { get; init; }

    [Column("province_id")]
    public int ProvinceId { get; set; }

    public Province Province { get; init; }

    [Column("district_id")]
    public int DistrictId { get; set; }

    public District District { get; init; }

    [Column("ward_id")]
    public int WardId { get; set; }

    public Ward Ward { get; init; }
}