using Common.Models.Orders;
using Common.Models.Products;
using DataLayer.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.OrderDetails
{
    public class OrderDetailViewModel:BaseViewModel
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
