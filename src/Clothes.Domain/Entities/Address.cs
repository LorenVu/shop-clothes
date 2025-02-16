using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Address")]
public class Address : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Addresses { get; private set; }
    
    [Required]
    [Column(TypeName = "varchar(15)")]
    public string AddressType { get; private set; }
    
    [Column(TypeName = "varchar(255)")]
    public string PostalCode { get; private set; }
    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
    
    //RelationShip
    public int CountryId { get; private set; }
    public Country Country { get; set; } = null!;
    
    public int ProvinceId { get; private set; }
    public Province Province { get; set; } = null!;
    
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;
    
    public int WardId { get; private set; }
    public Ward Ward { get; set; } = null!;
    
    public Guid UserId { get; private set; }
    public User User { get; set; } = null!;
}