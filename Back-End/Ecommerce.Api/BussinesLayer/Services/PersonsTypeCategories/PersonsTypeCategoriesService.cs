using AutoMapper;
using BussinesLayer.Interfaces.PersonsTypeCategories;
using BussinesLayer.Repositories.Core;
using Common.Models.PersonTypeCategories;
using DataLayer.Contexts;
using DataLayer.ViewModels.PersonsTypeCategories;

namespace BussinesLayer.Services.PersonsTypeCategories
{
    public class PersonsTypeCategoriesService : Repository<PersonTypeCategory, PersonTypeCategoryViewModel, MainDbContext>, IPersonsTypeCategoriesService
    {
        private MainDbContext _context;

        public PersonsTypeCategoriesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
