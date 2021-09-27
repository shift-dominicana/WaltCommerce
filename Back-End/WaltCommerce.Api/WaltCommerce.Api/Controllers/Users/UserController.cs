using BussinesLayer.Interfaces.BuyCarts;
using BussinesLayer.Interfaces.Users;
using Common.Enums;
using Common.Models.BuyCarts;
using Common.Models.Users;
using DataLayer.ViewModels.Users;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace WaltCommerce.Api.Controllers.Users
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
