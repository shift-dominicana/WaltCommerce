using AutoMapper;
using Common.Models.ProductsColors;
using DataLayer.ViewModels.ProductsColors;

namespace DataLayer.MappingProfiles.ProductsColors
{
    public class ProductColorsMap : Profile
    {
        public ProductColorsMap()
        {
            CreateMap<ProductColor, ProductColorViewModel>();
        }
    }
}
