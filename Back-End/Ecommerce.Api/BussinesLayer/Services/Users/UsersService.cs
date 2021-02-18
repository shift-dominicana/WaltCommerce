using AutoMapper;
using BussinesLayer.Interfaces.Users;
using BussinesLayer.Repositories.Core;
using Common.Enums;
using Common.Models.BuyCarts;
using Common.Models.Users;
using DataLayer.Contexts;
using DataLayer.ViewModels.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Users
{
    public class UsersService : Repository<User, UserViewModel, MainDbContext>, IUsersService
    {
        private MainDbContext _context;
        private readonly IMapper _mapper;

        public UsersService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public override async Task<UserViewModel> CreateAsync(User entity)
        {

            await _context.AddAsync(entity);
            await CommitAsync();
            
            var car = new BuyCart()
            {
                User = entity,
                IsDeleted = false,
                isPickup = true,
                payMode = PayModeEnum.CASH,
                CreationDate = DateTime.Now,
                CreatedBy = "Admin",
                taxReceipt = false

            };
            await _context.AddAsync(car);
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<UserViewModel>(entity);
                return mapped;
            }
            return null;
        }

    }
}
