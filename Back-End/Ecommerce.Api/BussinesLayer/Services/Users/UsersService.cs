using AutoMapper;
using BussinesLayer.Interfaces.Users;
using BussinesLayer.Repositories.Core;
using DataLayer.Contexts;
using DataLayer.Models.Users;
using DataLayer.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Users
{
    public class UsersService : Repository<User, UserViewModel, MainDbContext>, IUsersService
    {
        private MainDbContext _context;

        public UsersService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            // TODO: Compare by HASH MD5 or SHA
            if (user.Password != password)
                return null;

            return user;
        }

    }
}
