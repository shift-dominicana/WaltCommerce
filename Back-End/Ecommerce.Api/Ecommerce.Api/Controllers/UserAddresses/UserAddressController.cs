using BussinesLayer.Interfaces.UserAddresses;
using Common.Models.UsersAddresses;
using DataLayer.ViewModels.UserAddresses;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers.UserAddresses
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UserAddressController : CoreController<IUserAddressesService, UserAddress, UserAddressViewModel>
    {

        private IUserAddressesService _userAddressService;

        public UserAddressController(IUserAddressesService service) : base(service)
        {
            _userAddressService = service;
        }

        [HttpGet("GetUserAddresses/{userId}")]
        public async Task<IActionResult> GetUserAddresses(int userId)
        {
            var userAddresses = await _userAddressService.GetUserAddress(userId);
            return Ok(userAddresses);
        }
    }
}
