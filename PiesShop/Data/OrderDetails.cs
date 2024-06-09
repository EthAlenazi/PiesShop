using PiesShop.Models;

namespace PiesShop.Data
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int pieid { get; set; }
        public int Amount { get; set; }
        public int price { get; set; }

    }
}
