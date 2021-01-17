using BussinesLayer.Interfaces.PersonsTypeCategories;
using Common.Models.PersonTypeCategories;
using DataLayer.ViewModels.PersonsTypeCategories;
using Ecommerce.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers.PersonsTypeCategories
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
