using BussinesLayer.Interfaces.BuyCarts;
using Common.Models.BuyCarts;
using DataLayer.ViewModels.BuyCarts;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers.BuyCarts
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyCartController : CoreController<IBuyCartsService, BuyCart, BuyCartViewModel>
    {
        private IBuyCartsService _buyCartService;
        public BuyCartController(IBuyCartsService service) : base(service)
        {
            this._buyCartService = service;
        }
    }
}
