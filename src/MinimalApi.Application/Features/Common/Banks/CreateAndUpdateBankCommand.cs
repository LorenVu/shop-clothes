using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Application.Features.Common.Banks;

public class CreateAndUpdateBankCommand
{
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string NameEn { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Code { get; set; }

    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
}