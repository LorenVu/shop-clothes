using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Entities;

[Table("Address")]
public class Address : EntityAuditBase<int>, IStatusTracking
{
    public string Addresses { get; set; }
    public string AddressType { get; set; }
    public string PostalCode { get; set; }
    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
    
    //RelationShip
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
    
    public int ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
    
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;
    
    public int WardId { get; set; }
    public Ward Ward { get; set; } = null!;
    
    public long UserId { get; set; }
    public Customer Customer { get; set; } = null!;

}