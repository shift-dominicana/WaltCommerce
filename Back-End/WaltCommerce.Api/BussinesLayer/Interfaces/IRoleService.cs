using BussinesLayer.Repositories.Core;
using Common.Models.Roles;
using DataLayer.ViewModels.Roles;

namespace BussinesLayer.Interfaces
{
    public interface IRoleService : IRepository<Role, RoleViewModel>
    {

    }
}
