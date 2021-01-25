using Common.Models.Products;
using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.ProductsImages
{
    public class ProductImageViewModel : BaseViewModel
    {
        public Product ProductId { get; set; }

        public int OrderNumber { get; set; }

        public string Description { get; set; }
    }
}
