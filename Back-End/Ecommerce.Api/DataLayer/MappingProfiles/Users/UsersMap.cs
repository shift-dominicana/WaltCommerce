using AutoMapper;
using Common.Models.Users;
using DataLayer.ViewModels.Users;

namespace DataLayer.MappingProfiles.Users
{
    public class UsersMap : Profile
    {
        public UsersMap()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
