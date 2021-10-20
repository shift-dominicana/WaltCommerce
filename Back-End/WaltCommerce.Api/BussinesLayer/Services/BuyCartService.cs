using AutoMapper;
using BussinesLayer.Interfaces.BuyCarts;
using BussinesLayer.Repositories.Core;
using Common.Models.BuyCarts;
using DataLayer.Contexts;
using DataLayer.ViewModels.BuyCarts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class BuyCartService : Repository<BuyCart, BuyCartViewModel, MainDbContext>, IBuyCartsService
    {

        private MainDbContext _context;
        private readonly IMapper _mapper;

        public BuyCartService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<BuyCartViewModel> CreateAsync(BuyCart entity)
        {
            _context.Entry(entity.User).State = EntityState.Unchanged;
            await _context.AddAsync(entity);
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<BuyCartViewModel>(entity);
                return mapped;
            }
            return null;
        }
    }
}
