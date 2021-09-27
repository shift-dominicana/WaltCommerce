using BussinesLayer.Interfaces.Orders;
using Common.Models.Orders;
using DataLayer.ViewModels.Orders;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers.Orders
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CoreController<IOrderService, Order, OrderViewModel>
    {
        private IOrderService _orderService;
        public OrderController(IOrderService service) : base(service)
        {
            this._orderService = service;
        }
    }
}
