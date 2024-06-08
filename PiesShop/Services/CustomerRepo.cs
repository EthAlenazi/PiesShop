using PiesShop.Models;

namespace PiesShop.Services
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ShopDBContext context;

        public CustomerRepo(ShopDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customers> GetCustomers()
        {
            return context.Customers.ToList();
        }
    }
}
