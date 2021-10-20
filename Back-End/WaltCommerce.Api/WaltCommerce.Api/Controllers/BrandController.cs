using BussinesLayer.Interfaces;
using Common.Models.Brands;
using DataLayer.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : CoreController<IBrandService, Brand, BrandViewModel>
    {
        private IBrandService _brandService;

        public BrandController(IBrandService service) : base(service)
        {
            this._brandService = service;
        }

    }
}
