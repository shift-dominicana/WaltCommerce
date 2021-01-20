using BussinesLayer.Repositories.Core;
using Common.Models.Users;
using DataLayer.ViewModels.Users;

namespace BussinesLayer.Interfaces.Users
{
    public interface IUsersService : IRepository<User, UserViewModel>
    {
        public User Authenticate(string email, string password);
    }
}
