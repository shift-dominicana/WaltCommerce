using AutoMapper;
using BussinesLayer.Interfaces.OrderDetails;
using BussinesLayer.Repositories.Core;
using Common.Models.OrderDetails;
using DataLayer.Contexts;
using DataLayer.ViewModels.OrderDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.OrderDetails
{
    public class OrderDetailService : Repository<OrderDetail, OrderDetailViewModel, MainDbContext>, IOrderDetailService
    {
        private readonly IMapper _mapper;
        private MainDbContext _context;

        public OrderDetailService(MainDbContext context,IMapper mapper) : base(context,mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public override async Task<OrderDetailViewModel> CreateAsync(OrderDetail entity)
        {
            _context.Entry(entity.Order).State = EntityState.Unchanged;
            _context.Entry(entity.Product).State = EntityState.Unchanged;
            await _context.AddAsync(entity);
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<OrderDetailViewModel>(entity);
                return mapped;
            }
            return null;
        }

        public async Task<IEnumerable<OrderDetail>> GetUserOrderDetail(int id)
        {
            var products = await _context.OrderDetail.Where(c => c.Order.Id == id)
            .Include(p => p.Product)
            .ToListAsync();

            return products;
        }

    }
}
