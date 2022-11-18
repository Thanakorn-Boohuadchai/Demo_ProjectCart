namespace Demo_ProjectCart.Models.Request;

public class AddCartRequest
{
    public string OrderName { get; set; }
    public decimal Price { get; set; }
    public int amount { get; set; }
}