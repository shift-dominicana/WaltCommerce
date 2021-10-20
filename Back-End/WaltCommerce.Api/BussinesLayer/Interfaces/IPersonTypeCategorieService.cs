using BussinesLayer.Repositories.Core;
using Common.Models.PersonTypeCategories;
using DataLayer.ViewModels.PersonsTypeCategories;

namespace BussinesLayer.Interfaces
{
    public interface IPersonTypeCategorieService : IRepository<PersonTypeCategory, PersonTypeCategoryViewModel>
    {

    }
}
