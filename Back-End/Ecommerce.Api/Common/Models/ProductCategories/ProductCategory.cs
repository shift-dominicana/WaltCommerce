using Common.Models.Core;
using Common.Models.Products;
using System.Collections.Generic;

namespace Common.Models.ProductCategories
{
    public class ProductCategory : BaseModel
    {
        public string Identificator { get; set; }
        public string Description { get; set; }
        public bool OnTopInMainPage { set; get; } //Present category on Top of the list
        public ICollection<Product> Products { set; get; }
    }
}
