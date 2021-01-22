using BussinesLayer.Interfaces.Auth;
using BussinesLayer.Interfaces.Users;
using Common.Models.TokenRequest;
using Common.Models.Users;
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
        public IActionResult Login(UserRequest user)
        {
            var response = _userService.Authenticate(user.Email, user.Password);
            if (response == null) return BadRequest("invalid login");
            var token = _service.BuildToken(response);
            
            var UserResponse  = new
            {
                Email = response.Email,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Dob = response.Dob,
                Telephone = response.Telephone,
                Token = token
            };
            

            return Ok(UserResponse);
        }

    }
}
