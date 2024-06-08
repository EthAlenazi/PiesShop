using PiesShop.Models;

namespace PiesShop.Services
{
    public class PieReposetory : IPieRepository
    {
        private readonly ShopDBContext context;

        public PieReposetory(ShopDBContext context)
        {
            this.context = context;
        }

        public List<Pie> AllPies => context.Pies.ToList();

        public IEnumerable<Pie> GetPiesOfWeek => context.Pies.Where(P=> P.IsPieOfTheWeek == true);
        public Pie GetById(int id)
        {
            return context.Pies.FirstOrDefault(x=>x.PieId == id);  
        } 
       
    }
}
