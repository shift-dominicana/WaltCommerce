using BussinesLayer.Interfaces;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : CoreController<IProductCategorieService, ProductCategory, ProductCategoryViewModel>
    {
        private IProductCategorieService _productCategoryService;

        public ProductCategoryController(IProductCategorieService service) : base(service)
        {
            this._productCategoryService = service;
        }

    }
}
