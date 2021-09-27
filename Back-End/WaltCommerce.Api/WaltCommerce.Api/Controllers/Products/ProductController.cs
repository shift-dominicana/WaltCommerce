using BussinesLayer.Interfaces.Products;
using Common.Models.Products;
using DataLayer.ViewModels.Products;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CoreController<IProductsService, Product, ProductViewModel>
    {
        private IProductsService _productService;

        public ProductController(IProductsService service) : base(service)
        {
            this._productService = service;
        }
    }
}
