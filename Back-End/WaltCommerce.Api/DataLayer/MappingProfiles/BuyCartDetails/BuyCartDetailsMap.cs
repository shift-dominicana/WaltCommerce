using AutoMapper;
using Common.Models.BuyCartDetails;
using DataLayer.ViewModels.BuyCartDetails;

namespace DataLayer.MappingProfiles.BuyCartDetails
{
    public class BuyCartDetailsMap : Profile
    {
        public BuyCartDetailsMap()
        {
            CreateMap<BuyCartDetail, BuyCartDetailViewModel>();
        }
    }
}
