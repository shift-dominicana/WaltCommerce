using DataLayer.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.Users
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
