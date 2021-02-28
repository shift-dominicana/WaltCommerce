using BussinesLayer.Repositories.Core;
using Common.Models.UsersAddresses;
using DataLayer.ViewModels.UserAddresses;

namespace BussinesLayer.Interfaces.UserAddresses
{
    public interface IUserAddressesService : IRepository<UserAddress, UserAddressViewModel>
    {
    }
}
