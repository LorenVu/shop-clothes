using System.ComponentModel.DataAnnotations;

namespace Clothes.Domain.Enums;

public enum ECurrency
{
    [Display(Name = "VND")]
    Vnd,
    [Display(Name = "USD")]
    Usd,
    [Display(Name = "Euro")]
    Euro
}