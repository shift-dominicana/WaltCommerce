using AutoMapper;
using Common.Models.OrderDetails;
using DataLayer.ViewModels.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MappingProfiles.OrderDetails
{
    public class OrderDetailMap:Profile
    {
        public OrderDetailMap()
        {
            CreateMap<OrderDetail, OrderDetailViewModel>();
        }
    }
}
