using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("Categories")]
public class Category : EntityAuditBase<long>
{
    [Required]
    [Column("Name")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("Code")]
    [StringLength(100)]
    public string? Code { get; set; }

    [StringLength(150)]
    public string? Url { get; set; }

    [StringLength(50)]
    public string? Icon { get; set; }

    public int ParentId { get; set; }

    public int SortOrder { get; set; }


    public virtual ICollection<Product>? Products { get; set; }
}