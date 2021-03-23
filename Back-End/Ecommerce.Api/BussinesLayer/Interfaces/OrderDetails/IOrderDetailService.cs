using BussinesLayer.Repositories.Core;
using Common.Models.OrderDetails;
using DataLayer.ViewModels.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces.OrderDetails
{
    public interface IOrderDetailService : IRepository<OrderDetail, OrderDetailViewModel>
    {
        
    }
}
