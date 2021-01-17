using Common.Models.Brands;
using Common.Models.Core;
using Common.Models.PersonTypeCategories;
using Common.Models.ProductCategories;
using Common.Models.ProductsColors;
using Common.Models.ProductsImages;
using Common.Models.ProductsSpecifications;
using Common.Models.Sizes;
using System;
using System.Collections.Generic;

namespace DataLayer.Models.Products
{
    public class Product : BaseModel
    {
        public ICollection<ProductImage> ProductImages { set; get; }
        public ICollection<ProductSpecification> Specs { set; get; }
        public String MainImageUrl { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Identificator { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public ProductColor ProductColor { get; set; }
        public bool isEnabled { get; set; }
        public Brand ProductBrand { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public bool hasSizes { get; set; }
        public ProductSize ProductSize { get; set; }
        public PersonTypeCategory forPersonType { set; get; } //Men, Women, Kids, Elder, 
        public float PriceDiscount { set; get; }
        public bool OnTopInMainPage { set; get; } //Present product on Top of the list
        public bool isNewProduct { set; get; }
        public String Model { get; set; }

    }
}
