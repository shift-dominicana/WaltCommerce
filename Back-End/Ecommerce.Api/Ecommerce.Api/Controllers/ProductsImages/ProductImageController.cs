using BussinesLayer.Interfaces.ProductsImages;
using Common.Models.ProductsImages;
using DataLayer.ViewModels.ProductsImages;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.ProductsImages
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
