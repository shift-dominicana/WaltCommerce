using BussinesLayer.Repositories.Core;
using Common.Models.Orders;
using DataLayer.ViewModels.Orders;

namespace BussinesLayer.Interfaces
{
    public interface IOrderService : IRepository<Order, OrderViewModel>
    {

    }
}
