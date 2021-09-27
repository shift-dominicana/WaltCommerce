using AutoMapper;
using Common.Models.Roles;
using DataLayer.ViewModels.Roles;

namespace DataLayer.MappingProfiles.Roles
{
    class RolesMap : Profile
    {
        public RolesMap()
        {
            CreateMap<Role, RoleViewModel>();
        }
    }
}
