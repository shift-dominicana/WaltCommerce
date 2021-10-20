using BussinesLayer.Interfaces;
using Common.Models.PersonTypeCategories;
using DataLayer.ViewModels.PersonsTypeCategories;
using Microsoft.AspNetCore.Mvc;
using WaltCommerce.Api.Controllers.Core;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypeCategoryController : CoreController<IPersonTypeCategorieService, PersonTypeCategory, PersonTypeCategoryViewModel>
    {
        private IPersonTypeCategorieService _personTypeCategoryService;

        public PersonTypeCategoryController(IPersonTypeCategorieService service) : base(service)
        {
            this._personTypeCategoryService = service;
        }

    }
}
