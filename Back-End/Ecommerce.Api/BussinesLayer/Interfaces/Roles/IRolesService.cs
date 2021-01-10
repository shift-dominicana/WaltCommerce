using BussinesLayer.Repositories.Core;
using DataLayer.Models.Roles;
using DataLayer.ViewModels.Roles;

namespace BussinesLayer.Interfaces.Roles
{
    public interface IRolesService : IRepository<Role, RoleViewModel>
    {

    }
}
