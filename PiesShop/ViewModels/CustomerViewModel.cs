using PiesShop.Models;

namespace PiesShop.ViewModel
{
    public class CustomerViewModel
    {
        public string CurrentCategory;
        public List<Customers> Customers;
        public CustomerViewModel(string Title, List<Customers> Pies)
        {
            this.CurrentCategory = Title;
            this.Customers = Pies;
        }
    }
}
