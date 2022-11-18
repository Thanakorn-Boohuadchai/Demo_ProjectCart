using Demo_ProjectCart.Data;
using Demo_ProjectCart.Models;
using Demo_ProjectCart.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_ProjectCart.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : Controller
{
    private readonly CartAPIDbcontext dbcontext;

    public CartController(CartAPIDbcontext dbcontext)
    {
        this.dbcontext = dbcontext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        return Ok(await dbcontext.Cart.ToListAsync());
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCart([FromRoute] Guid id)
    {
        var cart = await dbcontext.Cart.FindAsync(id);

        if (cart == null)
        {
            return NotFound();
        }

        return Ok(cart);
    } 

    [HttpPost]
    public async Task<IActionResult> AddCart(AddCartRequest addCartRequest)
    {
        var cart = new Cart()
        {
            Id = Guid.NewGuid(),
            OrderName = addCartRequest.OrderName,
            Price = addCartRequest.Price,
            amount = addCartRequest.amount
        };

        await dbcontext.Cart.AddAsync(cart);
        await dbcontext.SaveChangesAsync();

        return Ok(cart);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCart([FromRoute] Guid id, UpdateCartRequest updateCartRequest)
    {
        var cart = dbcontext.Cart.Find(id);

        if (cart != null)
        {
            cart.OrderName = updateCartRequest.OrderName;
            cart.Price = updateCartRequest.Price;
            cart.amount = updateCartRequest.amount;

            await dbcontext.SaveChangesAsync();

            return Ok(cart);
        }

        return NotFound();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCart([FromRoute] Guid id)
    {
        var cart = await dbcontext.Cart.FindAsync(id);

        if (cart != null)
        {
            dbcontext.Remove(cart);
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

        return NotFound();
    }
}