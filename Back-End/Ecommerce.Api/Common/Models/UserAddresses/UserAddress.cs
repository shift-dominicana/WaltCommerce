using Common.Models.Core;
using Common.Models.Users;
using System;

namespace Common.Models.UsersAddresses
{
    public class UserAddress : BaseModel
    {
        public String Name { get; set; }
        public String Reference { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public User User { get; set; }
        public String Street { get; set; }
        public String Sector { get; set; }
        public String HouseNumber { get; set; }
        public String City { get; set; }
        public String Telephone { get; set; }
        public String Province { get; set; }
    }
}
