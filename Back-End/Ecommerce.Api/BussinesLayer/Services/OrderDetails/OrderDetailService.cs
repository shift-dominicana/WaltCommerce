using AutoMapper;
using BussinesLayer.Interfaces.OrderDetails;
using BussinesLayer.Repositories.Core;
using Common.Models.OrderDetails;
using DataLayer.Contexts;
using DataLayer.ViewModels.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.OrderDetails
{
    public class OrderDetailService : Repository<OrderDetail, OrderDetailViewModel, MainDbContext>, IOrderDetailService
    {
        private MainDbContext _context;

        public OrderDetailService(MainDbContext context,IMapper mapper) : base(context,mapper)
        {

        }
        
    }
}
