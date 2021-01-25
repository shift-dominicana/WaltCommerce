using Common.Models.Core;
using Common.Models.Products;

namespace Common.Models.ProductsSpecifications
{
    public class ProductSpecification : BaseModel
    {
        public Product Product { get; set; }

        public int OrderNumber { get; set; }

        public string Description { get; set; }

    }
}
