using Demo_ProjectCart.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_ProjectCart.Data;

public class CartAPIDbcontext : DbContext
{
    public CartAPIDbcontext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cart> Cart { get; set; }
}