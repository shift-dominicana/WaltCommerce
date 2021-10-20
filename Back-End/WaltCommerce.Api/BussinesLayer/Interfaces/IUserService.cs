using BussinesLayer.Repositories.Core;
using Common.Models.Users;
using DataLayer.ViewModels.Users;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IUserService : IRepository<User, UserViewModel>
    {
        public Task<User> Authenticate(string email, string password);
    }
}
