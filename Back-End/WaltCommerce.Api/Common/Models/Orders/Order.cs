using Common.Enums;
using Common.Models.Core;
using Common.Models.OrderDetails;
using Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Orders
{
    public class Order:BaseModel
    {
        public User User { get; set; }
        public string TrackingNumber { get; set; }
        public OrderStatusEnum Status { get; set; }
        public bool IsPaid { get; set; }
        public PayModeEnum PayMode { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public bool isPickup { get; set; }
    }
}
