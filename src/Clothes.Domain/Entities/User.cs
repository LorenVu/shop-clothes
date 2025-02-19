using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("users")]
public class User(string userName, string password, string salt) : EntityAuditBase<Guid>, IStatusTracking
{
    [Required]
    [Column("username", TypeName = "varchar(50)")]
    public string UserName { get; private set; } = userName;

    [Required]
    [Column("password", TypeName = "varchar(50)")]
    public string Password { get; private set; } = password;

    [Column("fullname", TypeName = "varchar(150)")]
    public string? FullName { get; init; }

    [Column("firstname", TypeName = "varchar(50)")]
    public string? FirstName { get; init; }

    [Column("lastname", TypeName = "varchar(50)")]
    public string? LastName { get; init; }

    [Column("picture_url", TypeName = "varchar(255)")]
    public string? PictureUrl { get; init; }

    [Required]
    [EmailAddress]
    [Column("email_address", TypeName = "varchar(100)")]
    public string? EmailAddress { get; init; }

    [Column("salt", TypeName = "varchar(255)")]
    public string Salt { get; private set; } = salt;

    [Column("is_active", TypeName = "byte")]
    public int IsActive { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    //Relationship
    public ICollection<Address> Addresses { get; init; } = null!;
}