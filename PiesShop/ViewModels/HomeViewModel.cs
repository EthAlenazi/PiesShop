using PiesShop.Models;

namespace PiesShop.ViewModel
{
    public class HomeViewModel
    {
        public string CurrentCategory;
        public List<Pie> PiesOfTheWeek;
        public HomeViewModel(string Title, List<Pie> Pies)
        {
            this.CurrentCategory = Title;
            this.PiesOfTheWeek = Pies;
        }
    }
}
