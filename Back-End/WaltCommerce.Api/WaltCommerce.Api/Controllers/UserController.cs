using BussinesLayer.Interfaces.BuyCarts;
using BussinesLayer.Interfaces.Users;
using Common.Models.Users;
using DataLayer.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;


namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CoreController<IUsersService, User, UserViewModel>
    {
        private IUsersService _userService;
        private readonly IBuyCartsService _buyCartsService;

        public UserController(IUsersService service, IBuyCartsService buyCartsService) : base(service)
        {
            _userService = service;
            _buyCartsService = buyCartsService;
        }

    }
}
