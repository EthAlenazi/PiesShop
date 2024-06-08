using PiesShop.Services;
using PiesShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace PiesShop.Components
{
    public class CategoryMenu: ViewComponent
    {
        ICategoryRepository category;
        public CategoryMenu(ICategoryRepository category)
        {
            this.category = category;
        }
        public IViewComponentResult Invoke()
        {
            var items = category.AllCategories.OrderBy(s => s.CategoryName);
            return View(items);
        }

    }
}
