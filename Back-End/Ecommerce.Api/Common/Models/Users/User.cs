using Common.Enums;
using Common.Models.Core;
using System;

namespace Common.Models.Users
{
    public class User : BaseModel
    {

        public String Email { get; set; }

        public String Password { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String NickName { get; set; }

        public DateTime Dob { get; set; } //Date of Birth

        public String Telephone { get; set; }

        public String CellPhone { get; set; }

        public String PersonalId { get; set; }

        public PersonalIdTypeEnum PersonalIdType { get; set; }

        public GenderEnum Gender { get; set; }


    }
}
