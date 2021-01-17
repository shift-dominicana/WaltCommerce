using BussinesLayer.Interfaces.Roles;
using Common.Models.Roles;
using DataLayer.ViewModels.Roles;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CoreController<IRolesService, Role, RoleViewModel>
    {
        private IRolesService _roleService;

        public RoleController(IRolesService service) : base(service)
        {
            this._roleService = service;
        }
    }
}
