using BussinesLayer.Interfaces.Auth;
using BussinesLayer.Interfaces.Users;
using Common.Models.UserRequest;
using Common.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUsersService _userService;

        public AuthController(IAuthService service, IUsersService userService)
        {
            _service = service;
            _userService = userService;
        }


        [HttpPost("Login")]
        public IActionResult Login(UserRequest credentials)
        {

            User user= _userService.Authenticate(credentials.Email, credentials.Password);

            if (user == null) return BadRequest("invalid login");
            var token = _service.BuildToken(user);

            var UserResponse = new
            {
                user,
                Token = token
            };


            return Ok(UserResponse);
        }

    }
}
