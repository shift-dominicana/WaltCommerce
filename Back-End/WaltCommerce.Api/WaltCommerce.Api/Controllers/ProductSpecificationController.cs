using BussinesLayer.Interfaces;
using Common.Models.ProductsSpecifications;
using DataLayer.ViewModels.ProductsSpecifications;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecificationController : CoreController<IProductSpecificationService, ProductSpecification, ProductSpecificationViewModel>
    {
        private IProductSpecificationService _productSpecificationService;

        public ProductSpecificationController(IProductSpecificationService service) : base(service)
        {
            this._productSpecificationService = service;
        }
    }
}
