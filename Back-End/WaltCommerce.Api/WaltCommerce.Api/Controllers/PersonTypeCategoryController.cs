using BussinesLayer.Interfaces.PersonsTypeCategories;
using Common.Models.PersonTypeCategories;
using DataLayer.ViewModels.PersonsTypeCategories;
using WaltCommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypeCategoryController : CoreController<IPersonsTypeCategoriesService, PersonTypeCategory, PersonTypeCategoryViewModel>
    {
        private IPersonsTypeCategoriesService _personTypeCategoryService;

        public PersonTypeCategoryController(IPersonsTypeCategoriesService service) : base(service)
        {
            this._personTypeCategoryService = service;
        }

    }
}
