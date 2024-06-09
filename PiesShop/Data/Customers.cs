namespace PiesShop.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Category favoriteCategory { get; set; }
        public string imgeUrl { get; set; }

    }
}
