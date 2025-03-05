using System.ComponentModel.DataAnnotations;

namespace Basket.API.Entities;

public class CartItem
{
    [Required]
    [Range(1, double.PositiveInfinity, ErrorMessage = "The field {0} must be  >= {1}.")]
    public required int Quantity { get; set; }   
    
    [Range(0.1, double.PositiveInfinity, ErrorMessage = "The field {0} must be  >= {1}.")]
    public required decimal ItemPrice { get; set; }
    
    [Required]
    public required string ItemNo { get; set; }
    
    [Required]
    public required string ItemName { get; init; }
    public int AvailableQuantity { get; private set; }
    
    public void SetAvailableQuantity(int quantity) => (AvailableQuantity) = quantity;
}