using Common.Models.Core;
using Common.Models.Users;
using System;

namespace Common.Models.UsersAddresses
{
    public class UserAddress : BaseModel
    {
        public String Name { get; set; }
        public String Reference { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public User User { get; set; }
    }
}
