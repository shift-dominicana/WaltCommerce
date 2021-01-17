using AutoMapper;
using Common.Models.ProductsSpecifications;
using DataLayer.ViewModels.ProductsSpecifications;

namespace DataLayer.MappingProfiles.ProductsSpecifications
{
    public class ProductsSpecificationsMap : Profile
    {
        public ProductsSpecificationsMap()
        {
            CreateMap<ProductSpecification, ProductSpecificationViewModel>();
        }
    }
}
