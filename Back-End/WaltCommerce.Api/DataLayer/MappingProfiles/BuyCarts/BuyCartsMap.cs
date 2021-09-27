using AutoMapper;
using Common.Models.BuyCarts;
using DataLayer.ViewModels.BuyCarts;

namespace DataLayer.MappingProfiles.BuyCarts
{
    public class BuyCartsMap : Profile
    {
        public BuyCartsMap()
        {
            CreateMap<BuyCart, BuyCartViewModel>();
        }
    }
}
