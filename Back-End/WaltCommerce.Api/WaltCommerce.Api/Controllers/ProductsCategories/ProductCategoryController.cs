using BussinesLayer.Interfaces.ProductsCategories;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WaltCommerce.Api.Controllers.ProductsCategories
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
