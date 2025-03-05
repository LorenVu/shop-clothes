namespace Basket.API.Entities;

public class Cart
{
    public Cart()
    {
        
    }

    public Cart(string userName)
    {
        UserName = userName;
    }
    
    public string UserName { get; private set; }
    
    public string EmailAddress { get; set; }
    public List<CartItem> Items { get; set; } = [];

    public decimal TotalPrice => Items.Sum(item => item.ItemPrice * item.Quantity);
    
    public DateTimeOffset LastModifiedDate { get; set; } = DateTimeOffset.UtcNow;
    
    public string? JobId { get; set; }
}