using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.Roles;
using DataLayer.Contexts;
using DataLayer.ViewModels.Roles;

namespace BussinesLayer.Services
{
    public class RoleService : Repository<Role, RoleViewModel, MainDbContext>, IRoleService
    {
        public RoleService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
