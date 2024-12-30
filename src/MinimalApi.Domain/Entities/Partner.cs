using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Partners")]
public class Partner : EntityAuditBase<long>, IStatusTracking
{
    [Required]
    [Column(TypeName = "varchar(150)")]
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Code { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Address { get; set; }
    
    [Column(TypeName = "varchar(15)")]
    public string NumberPhone { get; set; }
    
    [Column(TypeName = "varchar(30)")]
    public string Fax { get; set; }
    
    [Column(TypeName = "varchar(30)")]
    public string TaxCode { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string BankAccountNumber { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string RepresentativeName { get; set; }
    
    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
    
    //RelationShip
    public long CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    public int BankId { get; set; }
    public Bank Bank { get; set; } = null!;
    
    public ICollection<Contract> Contract { get; set; } = null!;
}