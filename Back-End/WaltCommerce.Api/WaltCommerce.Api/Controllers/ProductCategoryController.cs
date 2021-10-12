using BussinesLayer.Interfaces.ProductsCategories;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
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

    }
}
