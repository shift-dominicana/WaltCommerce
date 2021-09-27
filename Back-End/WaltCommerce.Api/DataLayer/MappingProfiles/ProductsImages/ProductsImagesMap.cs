using AutoMapper;
using Common.Models.ProductsImages;
using DataLayer.ViewModels.ProductsImages;

namespace DataLayer.MappingProfiles.ProductsImages
{
    public class ProductsImagesMap : Profile
    {
        public ProductsImagesMap()
        {
            CreateMap<ProductImage, ProductImageViewModel>();
        }
    }
}
