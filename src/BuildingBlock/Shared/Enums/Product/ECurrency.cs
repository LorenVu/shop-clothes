using System.ComponentModel.DataAnnotations;

namespace BuildingBlock.Shared.Enums.Product;

public enum ECurrency
{
    [Display(Name = "VND")]
    Vnd,
    [Display(Name = "USD")]
    Usd,
    [Display(Name = "Euro")]
    Euro
}