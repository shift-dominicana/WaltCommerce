using AutoMapper;
using Common.Models.Brands;
using DataLayer.ViewModels.Brands;

namespace DataLayer.MappingProfiles.Brands
{
    public class BrandMap : Profile
    {
        public BrandMap()
        {
            CreateMap<Brand, BrandViewModel>();
        }
    }
}
