using BussinesLayer.Interfaces.ProductsImages;
using Common.Models.ProductsImages;
using DataLayer.ViewModels.ProductsImages;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : CoreController<IProductsImagesService, ProductImage, ProductImageViewModel>
    {
        private IProductsImagesService _productImageService;

        public ProductImageController(IProductsImagesService service) : base(service)
        {
            this._productImageService = service;
        }

    }
}
