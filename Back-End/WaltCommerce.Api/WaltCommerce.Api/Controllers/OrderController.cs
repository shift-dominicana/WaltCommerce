using BussinesLayer.Interfaces;
using Common.Models.Orders;
using DataLayer.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
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
