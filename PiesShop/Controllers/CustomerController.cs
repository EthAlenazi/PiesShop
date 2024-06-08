using PiesShop.Services;
using PiesShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace PiesShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo customer;

        public CustomerController(ICustomerRepo customer)
        {
            this.customer = customer;
        }
        public IActionResult List()
        {
            CustomerViewModel model = new CustomerViewModel("Our Customers", customer.GetCustomers().ToList());

            return View(model);
        }
    }
}
