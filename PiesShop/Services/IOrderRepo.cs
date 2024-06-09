using PiesShop.Data;

namespace PiesShop.Services
{
    public interface IOrderRepo
    {
        bool CreateOrder(Order order);
    }
}
