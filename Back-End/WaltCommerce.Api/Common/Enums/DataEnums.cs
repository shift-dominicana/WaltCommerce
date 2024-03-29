﻿namespace Common.Enums
{
    public enum PersonalIdTypeEnum
    {
        none = 0,
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

    public enum GenderEnum
    {
        none = 0,
        male = 1,
        female = 2,
        nobinary = 3
    }

    public enum PayModeEnum
    {
        CASH = 1,
        TRANSFER = 2,
        CARD = 3,
        PAYPAL = 4
    }

    public enum OrderStatusEnum 
    {
        Requested = 1,
        Dispatched = 2,
        Delivered = 3
    }
}
