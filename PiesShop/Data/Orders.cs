using PiesShop.Models;
using System.ComponentModel.DataAnnotations;

namespace PiesShop.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public string Customer { get; set; }
        [Required]
        public List<OrderDetails> OrderDetails { get; set; }
        [Required]
        public decimal Total { get; set; }
        public string Note { get; set; }=" ";
        
    }
}
