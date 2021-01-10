using AutoMapper;
using BussinesLayer.Interfaces.Roles;
using BussinesLayer.Repositories.Core;
using DataLayer.Contexts;
using DataLayer.Models.Roles;
using DataLayer.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Roles
{
    public class RolesService : Repository<Role, RoleViewModel, MainDbContext>, IRolesService
    {
        public RolesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
