using Microsoft.AspNetCore.Mvc;

namespace PiesShop.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
