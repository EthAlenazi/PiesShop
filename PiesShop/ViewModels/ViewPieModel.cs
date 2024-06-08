using PiesShop.Models;


namespace PiesShop.ViewModel
{
    public class ViewPieModel
    {
        public string CurrentCategory;
        public IEnumerable<Pie> Pies;
        public ViewPieModel(IEnumerable<Pie> Pies,string? Title)
        {
            this.CurrentCategory = Title;
            this.Pies = Pies;
        }
       
    }
}
