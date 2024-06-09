using Microsoft.EntityFrameworkCore;
using PiesShop.Data;

namespace PiesShop.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {

        }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<ShoppingCardItems> shoppingCardItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
