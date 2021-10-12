using BussinesLayer.Interfaces.Auth;
using BussinesLayer.Interfaces.BuyCarts;
using BussinesLayer.Interfaces.Users;
using Common.Models.UserRequest;
using Common.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUsersService _userService;
        private readonly IBuyCartsService _buyCartsService;

        public AuthController(IAuthService service, IUsersService userService,IBuyCartsService buyCartsService)
        {
            _service = service;
            _userService = userService;
            _buyCartsService = buyCartsService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserRequest credentials)
        {
            User user = await  _userService.Authenticate(credentials.Email, credentials.Password);

            if (user == null) return BadRequest("invalid login");
            var token = _service.BuildToken(user);

            var cart = await _buyCartsService.GetAsync(c => c.UserId == user.Id);

            var UserResponse = new
            {
                user,
                token,
                Cart = cart
            };


            return Ok(UserResponse);
        }

    }
}
