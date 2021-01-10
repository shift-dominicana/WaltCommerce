using DataLayer.Models.Core;
using DataLayer.Models.Roles;
using System;
using WebAPI.Utils.Enums;

namespace DataLayer.Models.Users
{
    public class User : BaseModel
    {
        
        public String UserName { get; set; }

        public String Password { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String NickName { get; set; }

        public String IdCard { get; set; }

        public CardTypeEnum IdCardType { get; set; }

        public DateTime Dob { get; set; } //Date of Birth

        public String Telephone { get; set; }

        public String CellPhone { get; set; }

        public Role Role { get; set; }

    }
}
