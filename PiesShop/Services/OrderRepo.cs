using PiesShop.Data;
using PiesShop.Models;

namespace PiesShop.Services
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ShopDBContext context;
        private readonly IShopingCard shopingCard;
        public OrderRepo(ShopDBContext context, IShopingCard shopingCard)
        {
            this.context = context;
            this.shopingCard = shopingCard;
        }
        public bool CreateOrder(Order order)
        {
            if (order != null)
            {
               order.OrderTime = DateTime.Now;
                List<ShoppingCardItems> items = shopingCard.GetShoppingCartItems();
                order.OrderDetails = new List<OrderDetails>();
                foreach (ShoppingCardItems? item in items)
                {
                    var orderDetails = new OrderDetails
                    {
                        Amount = item.Amaount,
                        pieid = item.Pie.PieId,
                        price = (int)item.Pie.Price
                    };
                 order.OrderDetails.Add(orderDetails);
                }
               context.Orders.Add(order);
                context.SaveChanges();
                  return true;
            }
            return false;
        }
    }
}
