using AutoMapper;
using BussinesLayer.Interfaces.Roles;
using BussinesLayer.Repositories.Core;
using Common.Models.Roles;
using DataLayer.Contexts;
using DataLayer.ViewModels.Roles;

namespace BussinesLayer.Services.Roles
{
    public class RolesService : Repository<Role, RoleViewModel, MainDbContext>, IRolesService
    {
        public RolesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
