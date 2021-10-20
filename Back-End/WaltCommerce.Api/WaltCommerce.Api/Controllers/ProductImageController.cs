using BussinesLayer.Interfaces.ProductsImages;
using Common.Models.ProductsImages;
using DataLayer.ViewModels.ProductsImages;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : CoreController<IProductImageService, ProductImage, ProductImageViewModel>
    {
        private IProductImageService _productImageService;

        public ProductImageController(IProductImageService service) : base(service)
        {
            this._productImageService = service;
        }

    }
}
