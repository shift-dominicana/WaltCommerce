using AutoMapper;
using Common.Models.Orders;
using DataLayer.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MappingProfiles.Orders
{
    public class OrderMap:Profile
    {
        public OrderMap()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
