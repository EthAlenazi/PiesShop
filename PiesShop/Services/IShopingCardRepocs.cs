using PiesShop.Models;

namespace PiesShop.Services
{
    public interface IShopingCard
    {
        void AddToCart(Pie pie);
        int RemoveFromCart(Pie pie);
        List<ShoppingCardItems> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCardItems> ShoppingCartItems { get; set; }
    }
}
