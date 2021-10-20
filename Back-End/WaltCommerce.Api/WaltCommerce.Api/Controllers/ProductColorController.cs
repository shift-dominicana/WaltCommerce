using BussinesLayer.Interfaces;
using Common.Models.ProductsColors;
using DataLayer.ViewModels.ProductsColors;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorController : CoreController<IProductColorService, ProductColor, ProductColorViewModel>
    {
        private IProductColorService _productColorService;

        public ProductColorController(IProductColorService service) : base(service)
        {
            this._productColorService = service;
        }

    }
}
