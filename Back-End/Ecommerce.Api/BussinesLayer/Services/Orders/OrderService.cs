using AutoMapper;
using BussinesLayer.Interfaces.Orders;
using BussinesLayer.Repositories.Core;
using Common.Models.Orders;
using DataLayer.Contexts;
using DataLayer.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Orders
{
    public class OrderService : Repository<Order, OrderViewModel, MainDbContext>, IOrderService
    {
        private MainDbContext _context;

        public OrderService(MainDbContext context,IMapper mapper) :base(context,mapper)
        {

        }
    }
}
