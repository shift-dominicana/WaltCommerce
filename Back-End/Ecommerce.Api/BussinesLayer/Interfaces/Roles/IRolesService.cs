using BussinesLayer.Repositories.Core;
using Common.Models.Roles;
using DataLayer.ViewModels.Roles;

namespace BussinesLayer.Interfaces.Roles
{
    public interface IRolesService : IRepository<Role, RoleViewModel>
    {

    }
}
