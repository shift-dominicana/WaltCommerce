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

        [HttpGet("Authenticate/{email}/{password}")]
        public IActionResult Authenticate([FromRoute] string email, [FromRoute] string password) {

            var user = _userService.Authenticate(email, password);

            if (user == null)
                return BadRequest("Email or password is incorrect");


            return Ok(new
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
                //Token = tokenString
            });

        }

    }
}
