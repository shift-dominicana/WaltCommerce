using Common.Enums;
using Common.Models.BuyCartDetails;
using Common.Models.Users;
using DataLayer.ViewModels.Core;
using System.Collections.Generic;

namespace DataLayer.ViewModels.BuyCarts
{
    public class BuyCartViewModel : BaseViewModel
    {
        public ICollection<BuyCartDetail> BuyCartDetails { get; set; }
        public User user { get; set; }
        public bool isPickup { get; set; }
        public PayModeEnum payMode { get; set; }
        public bool taxReceipt { get; set; } //Comprobante Fiscal *
    }
}
