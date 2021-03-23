using BussinesLayer.Interfaces.OrderDetails;
using BussinesLayer.Interfaces.Orders;
using Common.Models.OrderDetails;
using DataLayer.ViewModels.OrderDetails;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.OrdersDetails
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
    }
}
