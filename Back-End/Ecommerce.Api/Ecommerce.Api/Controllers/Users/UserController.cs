using BussinesLayer.Interfaces.Users;
using DataLayer.Models.Users;
using DataLayer.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Api.Controllers.Core;

namespace Ecommerce.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CoreController<IUsersService, User, UserViewModel>
    {
        private IUsersService _userService;
        public UserController(IUsersService service) : base(service)
        {
            this._userService = service;
        }

        [HttpGet("Authenticate/{username}/{password}")]
        public IActionResult Authenticate([FromRoute] string username, [FromRoute] string password) {

            var user = _userService.Authenticate(username, password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });


            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Token = tokenString
            });

        }

    }
}
