using BussinesLayer.Interfaces.BuyCartDetails;
using Common.Models.BuyCartDetails;
using DataLayer.ViewModels.BuyCartDetails;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers.BuyCartDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyCartDetailController : CoreController<IBuyCartDetailsService, BuyCartDetail, BuyCartDetailViewModel>
    {
        private IBuyCartDetailsService _buyCartDetailService;

        public BuyCartDetailController(IBuyCartDetailsService service) : base(service)
        {
            this._buyCartDetailService = service;
        }


        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems(int BuyCart)
        {

            var cartDetail = await _buyCartDetailService.GetList(c => c.BuyCartId == BuyCart && c.IsDeleted == false);
            //var List = (BuyCartDetail)cartDetail;
            return Ok(cartDetail);
        }
    }
}
