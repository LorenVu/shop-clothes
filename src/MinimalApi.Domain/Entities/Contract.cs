using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Entities;

[Table("Contracts")]
public class Contract : EntityAuditBase<int>, IStatusTracking
{ 
    [Required]
    [Column(TypeName = "varchar(150)")]
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Code { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string nonAccentCode { get; set; }
    
    [Required]
    public DateTimeOffset StartDate { get; set; }
    
    [Required]
    public DateTimeOffset EndDate { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string FileUrl { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string PhysicalFileUrl { get; set; }
    
    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
    
    // Relationship
    public long CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    public int PartnerId { get; set; }
    public Partner Partner { get; set; } = null!;
}