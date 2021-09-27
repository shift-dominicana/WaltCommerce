using Common.Models.Core;

namespace Common.Models.PersonTypeCategories
{
    public class PersonTypeCategory : BaseModel
    {
        public string Identificator { get; set; }
        public string Description { get; set; }
        public bool OnTopInMainPage { set; get; } //Present category on Top of the list
    }
}
