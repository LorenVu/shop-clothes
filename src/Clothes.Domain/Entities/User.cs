using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Users")]
public class User(string userName, string password) : EntityAuditBase<Guid>, IStatusTracking
{
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string UserName { get; set; } = userName;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Password { get; set; } = password;

    [Column(TypeName = "varchar(150)")]
    public string? FullName { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string? FirstName { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string? LastName { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string? PictureUrl { get; set; }
    
    [Required]
    [EmailAddress]
    [Column(TypeName = "varchar(100)")]
    public string? EmailAddress { get; set; }
    
    public int IsActive { get; set; }
    
    public int IsDeleted { get; set; }
    
    //Relationship
    public ICollection<Address> Addresses { get; set; } = null!;
}