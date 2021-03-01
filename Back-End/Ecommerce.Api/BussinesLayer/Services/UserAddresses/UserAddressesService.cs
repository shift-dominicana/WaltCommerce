﻿using AutoMapper;
using BussinesLayer.Interfaces.UserAddresses;
using BussinesLayer.Repositories.Core;
using Common.Models.UsersAddresses;
using DataLayer.Contexts;
using DataLayer.ViewModels.UserAddresses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Services.UserAddresses
{
    public class UserAddressesService : Repository<UserAddress, UserAddressViewModel, MainDbContext>, IUserAddressesService
    {
        private MainDbContext _context;
        private readonly IMapper _mapper;


        public UserAddressesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<UserAddressViewModel> EditAsync(UserAddress entity) 
        {
            _context.Entry(entity.User).State = EntityState.Unchanged;
            var updated = _context.Update(entity).Entity;
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<UserAddressViewModel>(updated);
                return mapped;
            }
            return null;

        }

        public override async Task<UserAddressViewModel> CreateAsync(UserAddress entity)
        {
            _context.Entry(entity.User).State = EntityState.Unchanged;
            await _context.AddAsync(entity);
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<UserAddressViewModel>(entity);
                return mapped;
            }
            return null;
        }

        public override async Task<IEnumerable<UserAddress>> GetAllAsync()
        {
            var addresses = await _context.UserAddresses.Include(addr => addr.User).ToListAsync();
            return addresses;
        }

        public override async Task<UserAddress> GeTModelByIdAsync(int id)
        {

            var address = await _context.UserAddresses.Include(addr => addr.User).SingleAsync(userAdd => userAdd.Id == id);
            return address;
        }
            
     
            
    }
}