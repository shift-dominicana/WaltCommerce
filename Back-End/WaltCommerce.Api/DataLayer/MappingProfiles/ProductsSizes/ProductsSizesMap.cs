using AutoMapper;
using Common.Models.Sizes;
using DataLayer.ViewModels.ProductsSizes;

namespace DataLayer.MappingProfiles.ProductsSizes
{
    public class ProductsSizesMap : Profile
    {
        public ProductsSizesMap()
        {
            CreateMap<ProductSize, ProductSizeViewModel>();
        }
    }
}
