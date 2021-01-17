using BussinesLayer.Repositories.Core;
using Common.Models.PersonTypeCategories;
using DataLayer.ViewModels.PersonsTypeCategories;

namespace BussinesLayer.Interfaces.PersonsTypeCategories
{
    public interface IPersonsTypeCategoriesService : IRepository<PersonTypeCategory, PersonTypeCategoryViewModel>
    {

    }
}
