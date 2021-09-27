using BussinesLayer.Repositories.Core;
using Common.Models.Users;
using DataLayer.ViewModels.Users;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces.Users
{
    public interface IUsersService : IRepository<User, UserViewModel>
    {
        public Task<User> Authenticate(string email, string password);
    }
}
