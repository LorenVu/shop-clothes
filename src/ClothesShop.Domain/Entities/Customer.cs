using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;

namespace Clothes.Domain.Entities;

[Table("customers")]
public class Customer : EntityAuditBase<Guid>, IStatusTracking
{
    public Customer(string userName, string password, string salt)
    {
        UserName = userName;
        Password = password;
        Salt = salt;
    }

    [Required]
    [Column("username", TypeName = "varchar(50)")]
    public string UserName { get; private set; }
    
    [Required]
    [Column("password", TypeName = "varchar(255)")]
    public string Password { get; private set; }

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
    public string Salt { get; private set; }

    [Column("status", TypeName = "int4")]
    public int Status { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}