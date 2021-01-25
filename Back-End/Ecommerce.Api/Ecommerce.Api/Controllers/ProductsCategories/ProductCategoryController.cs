using BussinesLayer.Interfaces.ProductsCategories;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers.ProductsCategories
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : CoreController<IProductsCategoriesService, ProductCategory, ProductCategoryViewModel>
    {
        private IProductsCategoriesService _productCategoryService;

        public ProductCategoryController(IProductsCategoriesService service) : base(service)
        {
            this._productCategoryService = service;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
        
            var list = await _productCategoryService.GetListProduct();
            if (list == null) return BadRequest("No se encontraron los productos!");
            return Ok(list);
        }
    }
}
