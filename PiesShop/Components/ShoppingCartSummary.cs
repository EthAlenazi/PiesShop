using PiesShop.Migrations;
using PiesShop.Models;
using PiesShop.Services;
using PiesShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace PiesShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShopingCard card;
        public ShoppingCartSummary(IShopingCard card)
        {
            this.card = card;
        }
        public IViewComponentResult Invoke()
        {
            var items = card.GetShoppingCartItems();
            card.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCardViewModel(card, card.GetShoppingCartTotal());
            return View(shoppingCartViewModel);

        }
    }

}
