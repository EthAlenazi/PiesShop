
using PiesShop.Models;

namespace PiesShop.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        ShopDBContext context;
        public CategoryRepository(ShopDBContext context)
        {
            this.context = context;   
        }
        public IEnumerable<Category> AllCategories => context.Categories.ToList();
    }
}
