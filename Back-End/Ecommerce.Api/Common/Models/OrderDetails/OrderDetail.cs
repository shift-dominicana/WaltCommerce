using Common.Enums;
using Common.Models.Core;
using Common.Models.Orders;
using Common.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.OrderDetails
{
    public class OrderDetail:BaseModel
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
      
    }
}
