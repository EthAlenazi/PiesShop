using PiesShop.Migrations;
using PiesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace PiesShop.Services
{
    public class ShopingCard : IShopingCard
    {
        private readonly ShopDBContext _context;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCardItems> ShoppingCartItems { get; set; } = default!;

        private ShopingCard(ShopDBContext bethanysPieShopDbContext)
        {
            _context = bethanysPieShopDbContext;
        }

        public static ShopingCard GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            ShopDBContext context = services.GetService<ShopDBContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);

            return new ShopingCard(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem =
                    _context.shoppingCardItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShopingCardId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCardItems
                {
                    ShopingCardId = ShoppingCartId,
                    Pie = pie,
                    Amaount = 1
                };

                _context.shoppingCardItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amaount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    _context.shoppingCardItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShopingCardId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amaount > 1)
                {
                    shoppingCartItem.Amaount--;
                    localAmount = shoppingCartItem.Amaount;
                }
                else
                {
                    _context.shoppingCardItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCardItems> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _context.shoppingCardItems.Where(c => c.ShopingCardId == ShoppingCartId)
                           .Include(s => s.Pie)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _context
                .shoppingCardItems
                .Where(cart => cart.ShopingCardId == ShoppingCartId);

            _context.shoppingCardItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.shoppingCardItems.Where(c => c.ShopingCardId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amaount).Sum();
            return total;
        }
    }
}
