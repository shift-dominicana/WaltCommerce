using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.ProductsCategories
{
    public class ProductCategoryViewModel : BaseViewModel
    {
        public string Identificator { get; set; }
        public string Description { get; set; }
        public bool OnTopInMainPage { set; get; } //Present category on Top of the list
    }
}
