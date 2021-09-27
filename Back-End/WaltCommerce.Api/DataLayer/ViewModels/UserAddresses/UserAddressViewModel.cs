using Common.Models.Users;
using DataLayer.ViewModels.Core;
using System;

namespace DataLayer.ViewModels.UserAddresses
{
    public class UserAddressViewModel : BaseViewModel
    {
        public String Name { get; set; }
        public String Reference { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public User User { get; set; }
        public String Street { get; set; }
        public String Sector { get; set; }
        public String HouseNumber { get; set; }
        public String City { get; set; }
        public String Telephone { get; set; }
    }
}
