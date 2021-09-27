using Common.Enums;
using Common.Models.OrderDetails;
using Common.Models.Users;
using DataLayer.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.Orders
{
    public class OrderViewModel : BaseViewModel
    {
        public User User { get; set; }
        public string TrackingNumber { get; set; }
        public OrderStatusEnum Status { get; set; }
        public bool IsPaid { get; set; }
        public PayModeEnum PayMode { get; set; }
        public ICollection<OrderDetail> Orders { get; set; }
        public bool IsDelivery { get; set; }
    
    }
}
