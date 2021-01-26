using Common.Enums;
using Common.Models.BuyCartDetails;
using Common.Models.Core;
using Common.Models.Users;
using System.Collections.Generic;

namespace Common.Models.BuyCarts
{
    public class BuyCart : BaseModel
    {
        public ICollection<BuyCartDetail> BuyCartDetails { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool isPickup { get; set; }

        public PayModeEnum payMode { get; set; }

        public bool taxReceipt { get; set; } //Comprobante Fiscal *

    }
}
