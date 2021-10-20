using BussinesLayer.Interfaces;
using Common.Models.Sizes;
using DataLayer.ViewModels.ProductsSizes;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : CoreController<IProductSizeService, ProductSize, ProductSizeViewModel>
    {
        private IProductSizeService _productSizeService;

        public ProductSizeController(IProductSizeService service) : base(service)
        {
            this._productSizeService = service;
        }

    }
}
