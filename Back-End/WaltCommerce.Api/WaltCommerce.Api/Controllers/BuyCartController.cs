using BussinesLayer.Interfaces.BuyCarts;
using Common.Models.BuyCarts;
using DataLayer.ViewModels.BuyCarts;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
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
