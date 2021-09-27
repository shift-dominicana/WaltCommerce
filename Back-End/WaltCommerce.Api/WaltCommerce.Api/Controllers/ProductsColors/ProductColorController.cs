using BussinesLayer.Interfaces.ProductsColors;
using Common.Models.ProductsColors;
using DataLayer.ViewModels.ProductsColors;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers.ProductsColors
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorController : CoreController<IProductsColorsService, ProductColor, ProductColorViewModel>
    {
        private IProductsColorsService _productColorService;

        public ProductColorController(IProductsColorsService service) : base(service)
        {
            this._productColorService = service;
        }

    }
}
