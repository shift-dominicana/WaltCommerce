using BussinesLayer.Repositories.Core;
using Common.Models.UsersAddresses;
using DataLayer.ViewModels.UserAddresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IUserAddressService : IRepository<UserAddress, UserAddressViewModel>
    {
        public Task<IEnumerable<UserAddress>> GetUserAddress(int id);
    }
}

