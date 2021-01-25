using AutoMapper;
using Common.Models.Products;
using DataLayer.ViewModels.Products;

namespace DataLayer.MappingProfiles.Products
{
    public class ProductsMap : Profile
    {
        public ProductsMap()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
