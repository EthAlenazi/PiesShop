using PiesShop.Services;
using PiesShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace PiesShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository pie;

        public HomeController(IPieRepository pie)
        {
            this.pie = pie;
        }
        public IActionResult Home()
        {
            HomeViewModel home = new HomeViewModel("Pies Of The Week", pie.GetPiesOfWeek.ToList());
            return View(home);
        }
    }
}
