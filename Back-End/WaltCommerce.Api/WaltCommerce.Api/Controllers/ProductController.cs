using BussinesLayer.Interfaces;
using Common.Models.Products;
using DataLayer.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CoreController<IProductService, Product, ProductViewModel>
    {
        private IProductService _productService;

        public ProductController(IProductService service) : base(service)
        {
            this._productService = service;
        }
    }
}
