using PiesShop.Services;
using PiesShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PiesShop.Models;

namespace PiesShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _category;
        public PieController(IPieRepository pieRepository, ICategoryRepository category)
        {
            _pieRepository = pieRepository;
            _category = category;
        }
        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _category.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new ViewPieModel(pies, currentCategory));
        }
        public IActionResult Details(int id) {
           var data=  _pieRepository.GetById(id);
            if (data==null)
                return NotFound();

            return View(data);
        }
    }
}
