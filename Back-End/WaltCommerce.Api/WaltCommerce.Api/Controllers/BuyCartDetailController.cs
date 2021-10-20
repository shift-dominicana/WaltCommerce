using BussinesLayer.Interfaces;
using Common.Models.BuyCartDetails;
using DataLayer.ViewModels.BuyCartDetails;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyCartDetailController : CoreController<IBuyCartDetailService, BuyCartDetail, BuyCartDetailViewModel>
    {
        private IBuyCartDetailService _buyCartDetailService;

        public BuyCartDetailController(IBuyCartDetailService service) : base(service)
        {
            this._buyCartDetailService = service;
        }


        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems(int BuyCart)
        {

            var cartDetail = await _buyCartDetailService.GetUserCartDetail(BuyCart);
            //var List = (BuyCartDetail)cartDetail;
            return Ok(cartDetail);
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public override async Task<IActionResult> Create(BuyCartDetail entity)
        {
            BuyCartDetail item = _buyCartDetailService.FindBy(Item => Item.Product.Id == entity.Product.Id && Item.IsDeleted == false).FirstOrDefault();
            BuyCartDetailViewModel reqResult = null;
            if (item is not null)
            {
                item.Quantity = item.Quantity + entity.Quantity;
                reqResult = await _buyCartDetailService.EditAsync(item);
            }
            else
            {
                reqResult = await _buyCartDetailService.CreateAsync(entity);
            }



            if (reqResult != null) return Ok(reqResult);
            return BadRequest("Error Creating the Entity");
        }
    }
}
