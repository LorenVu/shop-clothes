using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Entities;

public class Customer : EntityAuditBase<long>, IStatusTracking
{
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string CustomerName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Password { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(150)")]
    public string FullName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string PictureURL { get; set; }
    
    [Required]
    [EmailAddress]
    [Column(TypeName = "varchar(100)")]
    public string EmailAddress { get; set; }
    
    public int IsActive { get; set; }
    
    public int IsDeleted { get; set; }
    
    //Relationship
    public ICollection<IdentityCustomer> IdentityCustomer { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = null!;
    
    public ICollection<Partner> Partners { get; set; } = null!;
    public ICollection<Contract> Contracts { get; set; } = null!;
}