using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Entities;

public class IdentityCustomer : EntityBase<long>
{
    [Required]
    public int Type { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Number { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(150)")]
    public string FullName { get; set; }
    
    public int Gender { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset DateOfIssue { get; set; }
    public DateTimeOffset DateOfExpiry { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string Ethnic { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string Nationality { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string Religion { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string IdentitfyingCharacteristics { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string OldIdentityDocumentNumber { get; set; }
    
    public int OldIdentityDocumentType { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string PermanentAddress { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string PlaceOfBirth { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string TemporaryAddress { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string HomeTown { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string FatherFullName { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string MotherFullName { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string SpouseFullName { get; set; }
    
    public short VisaType { get; set; }
    
    [Column(TypeName = "varchar(15)")]
    public string VisaNumber { get; set; }
    
    //Relationship
    public long CustomerId { get; set; }
    public Customer? Customer { get; set; } = null;
}