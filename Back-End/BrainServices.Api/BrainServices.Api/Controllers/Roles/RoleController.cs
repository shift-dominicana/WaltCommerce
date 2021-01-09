using BussinesLayer.Interfaces.Roles;
using DataLayer.Models.Roles;
using DataLayer.ViewModels.Roles;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Core;

namespace BrainServices.Api.Controllers.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CoreController<IRolesService, Role, RoleViewModel>
    {
        public RoleController(IRolesService service) : base(service)
        {

        }
    }
}
