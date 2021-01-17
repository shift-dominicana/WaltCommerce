using Common.Models.Core;
using System;

namespace Common.Models.Roles
{
    public class Role : BaseModel
    {
        public String Name { get; set; }

        //Permissions

        public bool cancelPayment { get; set; }
        public bool usePos { get; set; } //Point Of Sales

        public bool addAppointment { get; set; }
        public bool removeAppointment { get; set; }

        public bool addArticles { get; set; }
        public bool editArticles { get; set; }
        public bool disableArticles { get; set; }

        public bool addServices { get; set; }
        public bool editServices { get; set; }
        public bool disableServices { get; set; }

        public bool editCompanyData { get; set; }

    }
}
