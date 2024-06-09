using Microsoft.AspNetCore.Mvc;
using PiesShop.Data;
using PiesShop.Migrations;
using PiesShop.Services;

namespace PiesShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShopingCard _card;
        private readonly IOrderRepo _order;
        public OrderController(IShopingCard card, IOrderRepo order)
        {
            this._card = card;
            this._order = order;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order )
        {
            var items = _card.GetShoppingCartItems();
            _card.ShoppingCartItems = items;

            if (_card.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            //if (ModelState.IsValid)
            //{
                _order.CreateOrder(order);
                _card.ClearCart();
                return RedirectToAction("CheckoutComplete");
            //}
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
