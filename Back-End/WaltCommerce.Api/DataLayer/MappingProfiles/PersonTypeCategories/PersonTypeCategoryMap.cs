using AutoMapper;
using Common.Models.PersonTypeCategories;
using DataLayer.ViewModels.PersonsTypeCategories;

namespace DataLayer.MappingProfiles.PersonTypeCategories
{
    public class PersonTypeCategoryMap : Profile
    {
        public PersonTypeCategoryMap()
        {
            CreateMap<PersonTypeCategory, PersonTypeCategoryViewModel>();
        }
    }
}
