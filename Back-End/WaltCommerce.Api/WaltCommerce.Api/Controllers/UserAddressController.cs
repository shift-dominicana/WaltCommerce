using BussinesLayer.Interfaces;
using Common.Models.UsersAddresses;
using DataLayer.ViewModels.UserAddresses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : CoreController<IUserAddressService, UserAddress, UserAddressViewModel>
    {

        private IUserAddressService _userAddressService;

        public UserAddressController(IUserAddressService service) : base(service)
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
