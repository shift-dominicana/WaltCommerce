using BussinesLayer.Interfaces.OrderDetails;
using Common.Models.OrderDetails;
using DataLayer.ViewModels.OrderDetails;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : CoreController<IOrderDetailService, OrderDetail, OrderDetailViewModel>
    {
        private IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService service) : base(service)
        {
            _orderDetailService = service;
        }

        [HttpGet("GetOrderItems")]
        public async Task<IActionResult> GetOrderItems(int OrderId)
        {

            var cartDetail = await _orderDetailService.GetUserOrderDetail(OrderId);
            //var List = (BuyCartDetail)cartDetail;
            return Ok(cartDetail);
        }

    }
}
