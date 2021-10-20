using BussinesLayer.Interfaces;
using Common.Models.Roles;
using DataLayer.ViewModels.Roles;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CoreController<IRoleService, Role, RoleViewModel>
    {
        private IRoleService _roleService;

        public RoleController(IRoleService service) : base(service)
        {
            this._roleService = service;
        }
    }
}
