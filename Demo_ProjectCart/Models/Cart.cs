namespace Demo_ProjectCart.Models;

public class Cart
{
    public Guid Id { get; set; }
    public string OrderName { get; set; }
    public decimal Price { get; set; }
    public int amount { get; set; }
    
}