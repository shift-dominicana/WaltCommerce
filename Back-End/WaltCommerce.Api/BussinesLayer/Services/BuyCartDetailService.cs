using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.BuyCartDetails;
using DataLayer.Contexts;
using DataLayer.ViewModels.BuyCartDetails;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class BuyCartDetailService : Repository<BuyCartDetail, BuyCartDetailViewModel, MainDbContext>, IBuyCartDetailService
    {
        private MainDbContext _context;
        private readonly IMapper _mapper;

        public BuyCartDetailService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<BuyCartDetailViewModel> CreateAsync(BuyCartDetail entity)
        {
            _context.Entry(entity.BuyCart).State = EntityState.Unchanged;
            _context.Entry(entity.Product).State = EntityState.Unchanged;
            await _context.AddAsync(entity);
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<BuyCartDetailViewModel>(entity);
                return mapped;
            }
            return null;
        }

        public async Task<IEnumerable<BuyCartDetail>> GetUserCartDetail(int id)
        {
            var products = await _context.BuyCartDetails.Where(c => c.BuyCartId == id && c.IsDeleted == false)
            .Include(p => p.Product)
            .ToListAsync();

            return products;
        }
    }
}
