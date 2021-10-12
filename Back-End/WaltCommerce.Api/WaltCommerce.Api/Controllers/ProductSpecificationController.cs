using BussinesLayer.Interfaces.ProductsSpecifications;
using Common.Models.ProductsSpecifications;
using DataLayer.ViewModels.ProductsSpecifications;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers
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
