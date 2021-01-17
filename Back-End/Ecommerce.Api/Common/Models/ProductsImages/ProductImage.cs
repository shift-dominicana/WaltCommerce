using Common.Models.Core;
using DataLayer.Models.Products;
using System;

namespace Common.Models.ProductsImages
{
    public class ProductImage : BaseModel
    {
        public Product Product { get; set; }

        public String ImageUrl { get; set; }

        public int OrderNumber { get; set; }

    }
}
