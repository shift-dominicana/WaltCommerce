using BussinesLayer.Interfaces.ProductsSpecifications;
using Common.Models.ProductsSpecifications;
using DataLayer.ViewModels.ProductsSpecifications;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.ProductsSpecifications
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecificationController : CoreController<IProductsSpecificationsService, ProductSpecification, ProductSpecificationViewModel>
    {
        private IProductsSpecificationsService _productSpecificationService;

        public ProductSpecificationController(IProductsSpecificationsService service) : base(service)
        {
            this._productSpecificationService = service;
        }
    }
}
