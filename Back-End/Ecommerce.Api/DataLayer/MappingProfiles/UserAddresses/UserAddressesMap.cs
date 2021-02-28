using AutoMapper;
using Common.Models.UsersAddresses;
using DataLayer.ViewModels.UserAddresses;

namespace DataLayer.MappingProfiles.UserAddresses
{
    class UserAddressesMap : Profile
    {
        public UserAddressesMap()
        {
            CreateMap<UserAddress, UserAddressViewModel>();
        }
    }
}
