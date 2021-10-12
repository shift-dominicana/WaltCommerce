using BussinesLayer.Interfaces.ProductsSizes;
using Common.Models.Sizes;
using DataLayer.ViewModels.ProductsSizes;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : CoreController<IProductsSizesService, ProductSize, ProductSizeViewModel>
    {
        private IProductsSizesService _productSizeService;

        public ProductSizeController(IProductsSizesService service) : base(service)
        {
            this._productSizeService = service;
        }

    }
}
