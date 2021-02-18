using BussinesLayer.Interfaces.BuyCarts;
using BussinesLayer.Interfaces.Users;
using Common.Enums;
using Common.Models.BuyCarts;
using Common.Models.Users;
using DataLayer.ViewModels.Users;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Ecommerce.Api.Controllers.Users
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

        [HttpGet("Authenticate/{email}/{password}")]
        public IActionResult Authenticate([FromRoute] string email, [FromRoute] string password)
        {

            var user = _userService.Authenticate(email, password);

            if (user == null)
                return BadRequest("Email or password is incorrect");
           

            return Ok(new
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Token = tokenString

            });

        }

        //public override async Task<IActionResult> Create(User entity)
        //{
        //    var userDto = base.Create(entity);


        //    var car = new BuyCart()
        //    {
        //        User = entity,
        //        IsDeleted = false,
        //        isPickup = true,
        //        payMode = PayModeEnum.CASH,
        //        CreationDate = DateTime.Now,
        //        CreatedBy = "Admin",
        //        taxReceipt = false

        //    };

        //    await _buyCartsService.CreateAsync(car);
        //    return Ok(userDto);
        //}


    }
}
