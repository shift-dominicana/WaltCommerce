using Common.Models.BuyCarts;
using Common.Models.Products;
using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.BuyCartDetails
{
    public class BuyCartDetailViewModel :  BaseViewModel
    {
        public BuyCart buyCart { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
