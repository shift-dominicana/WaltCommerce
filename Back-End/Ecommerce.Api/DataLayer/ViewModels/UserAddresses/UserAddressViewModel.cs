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
    }
}
