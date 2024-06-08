using PiesShop.Models;

namespace PiesShop.Services
{
    public interface ICustomerRepo
    {
        IEnumerable<Customers> GetCustomers();
    }
}
