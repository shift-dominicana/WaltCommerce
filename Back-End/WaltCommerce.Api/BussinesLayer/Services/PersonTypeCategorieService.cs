using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.PersonTypeCategories;
using DataLayer.Contexts;
using DataLayer.ViewModels.PersonsTypeCategories;

namespace BussinesLayer.Services
{
    public class PersonTypeCategorieService : Repository<PersonTypeCategory, PersonTypeCategoryViewModel, MainDbContext>, IPersonTypeCategorieService
    {
        private MainDbContext _context;

        public PersonTypeCategorieService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
