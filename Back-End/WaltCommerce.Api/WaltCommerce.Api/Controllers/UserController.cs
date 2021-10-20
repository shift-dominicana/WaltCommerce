using BussinesLayer.Interfaces;
using BussinesLayer.Interfaces.BuyCarts;
using Common.Models.Users;
using DataLayer.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;


namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CoreController<IUserService, User, UserViewModel>
    {
        private IUserService _userService;
        private readonly IBuyCartsService _buyCartsService;

        public UserController(IUserService service, IBuyCartsService buyCartsService) : base(service)
        {
            _userService = service;
            _buyCartsService = buyCartsService;
        }

    }
}
