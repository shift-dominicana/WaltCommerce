using BussinesLayer.Repositories.Core;
using Common.Models.Orders;
using DataLayer.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces.Orders
{
    public interface IOrderService : IRepository<Order, OrderViewModel>
    {
        
    }
}
