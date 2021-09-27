using BussinesLayer.Interfaces.Roles;
using Common.Models.Roles;
using DataLayer.ViewModels.Roles;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers.Roles
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
