using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.PersonsTypeCategories
{
    public class PersonTypeCategoryViewModel : BaseViewModel
    {
        public string Identificator { get; set; }
        public string Description { get; set; }
        public bool OnTopInMainPage { set; get; } //Present category on Top of the list
    }
}
