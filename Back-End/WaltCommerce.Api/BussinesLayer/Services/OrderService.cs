using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.Orders;
using DataLayer.Contexts;
using DataLayer.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class OrderService : Repository<Order, OrderViewModel, MainDbContext>, IOrderService
    {
        private MainDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<OrderViewModel> CreateAsync(Order entity)
        {
            _context.Entry(entity.User).State = EntityState.Unchanged;
            await _context.AddAsync(entity);
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<OrderViewModel>(entity);
                return mapped;
            }
            return null;
        }
    }
}
