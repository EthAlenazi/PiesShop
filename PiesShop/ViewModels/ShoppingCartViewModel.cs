using PiesShop.Services;

namespace PiesShop.ViewModel
{
    public class ShoppingCardViewModel
    {
        public ShoppingCardViewModel(IShopingCard shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }

        public IShopingCard ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
    }
}
