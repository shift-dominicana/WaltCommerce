using BussinesLayer.Repositories.Core;
using Common.Models.BuyCartDetails;
using DataLayer.ViewModels.BuyCartDetails;

namespace BussinesLayer.Interfaces.BuyCartDetails
{
    public interface IBuyCartDetailsService : IRepository<BuyCartDetail, BuyCartDetailViewModel>
    {

    }
}
