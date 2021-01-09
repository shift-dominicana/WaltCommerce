using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utils.Enums
{
    public enum CardTypeEnum
    {
        LocalId = 1,
        Passport = 2,
        BusinessId = 3
    }

    public enum ServiceTypeEnum
    {
        Combined = 1,
        Simple = 2,
        Additional = 3 
    }
    public enum AppointmentTypeEnum
    {
        domicile = 1,
        normal = 2,
    }
}
