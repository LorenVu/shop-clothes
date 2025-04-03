using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlock.Shared.Contracts.Domains;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;

[Table("users")]
public class User : EntityAuditBase<Guid>, IStatusTracking
{
    public User(string userName, string password, string salt)
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
    public string EmailAddress { get; set; }

    [Column("salt", TypeName = "varchar(255)")]
    public string Salt { get; private set; }

    [Column("status", TypeName = "int4")]
    public int Status { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
    
    #region Modified method

    public void ChangePassword(string password)
    {
        if (!string.IsNullOrWhiteSpace(password))
            this.Password = password;
    }
    
    public void ChangeEmail(string email)
    {
        if (!string.IsNullOrWhiteSpace(email))
            this.EmailAddress = email;
    }
    
    public void ChangeUsername(string username)
    {
        if (!string.IsNullOrWhiteSpace(username))
            this.UserName = username;
    }
    #endregion
}