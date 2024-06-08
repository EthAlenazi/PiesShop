using PiesShop.Models;

namespace PiesShop.Services
{
    public interface IPieRepository
    {
        List<Pie> AllPies { get; }
        IEnumerable<Pie> GetPiesOfWeek { get; }
        Pie GetById(int id);


    }
}
