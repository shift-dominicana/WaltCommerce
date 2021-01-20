using BussinesLayer.Interfaces.Auth;
using BussinesLayer.Interfaces.Users;
using Common.Models.TokenRequest;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUsersService _userService;

        public AuthController(IAuthService service,IUsersService userService)
        {
            _service = service;
            _userService = userService;
        }


        [HttpPost("Login")]
        public IActionResult Login(TokenRequest user)
        {
            var response = _userService.Authenticate(user.Email, user.Password);
            if (response == null) return BadRequest("invalid login");
            return Ok(_service.BuildToken(response));
        }

    }
}
