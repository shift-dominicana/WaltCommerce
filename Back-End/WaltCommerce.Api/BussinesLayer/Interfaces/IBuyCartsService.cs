using BussinesLayer.Repositories.Core;
using Common.Models.BuyCarts;
using DataLayer.ViewModels.BuyCarts;

namespace BussinesLayer.Interfaces.BuyCarts
{
    public interface IBuyCartsService : IRepository<BuyCart, BuyCartViewModel>
    {

    }
}
