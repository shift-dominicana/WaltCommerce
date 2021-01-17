using DataLayer.Models.Products;
using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.ProductsSpecifications
{
    public class ProductSpecificationViewModel : BaseViewModel
    {
        public Product ProductId { get; set; }

        public int OrderNumber { get; set; }

        public string Description { get; set; }
    }
}
