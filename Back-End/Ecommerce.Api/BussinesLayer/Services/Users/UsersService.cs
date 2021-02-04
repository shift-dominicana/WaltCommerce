using AutoMapper;
using BussinesLayer.Interfaces.Users;
using BussinesLayer.Repositories.Core;
using Common.Models.Users;
using DataLayer.Contexts;
using DataLayer.ViewModels.Users;
using System.Linq;

namespace BussinesLayer.Services.Users
{
    public class UsersService : Repository<User, UserViewModel, MainDbContext>, IUsersService
    {
        private MainDbContext _context;

        public UsersService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            // Compare by HASH MD5
            if (user.Password != password)
                return null;

            return user;
        }

    }
}
