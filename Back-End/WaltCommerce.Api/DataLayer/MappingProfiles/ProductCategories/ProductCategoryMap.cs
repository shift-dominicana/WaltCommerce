using AutoMapper;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;

namespace DataLayer.MappingProfiles.ProductCategories
{
    public class ProductCategoryMap : Profile
    {
        public ProductCategoryMap()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
