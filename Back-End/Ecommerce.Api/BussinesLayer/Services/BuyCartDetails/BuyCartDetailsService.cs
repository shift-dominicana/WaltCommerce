using AutoMapper;
using BussinesLayer.Interfaces.BuyCartDetails;
using BussinesLayer.Repositories.Core;
using Common.Models.BuyCartDetails;
using DataLayer.Contexts;
using DataLayer.ViewModels.BuyCartDetails;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BussinesLayer.Services.BuyCartDetails
{
    public class BuyCartDetailsService : Repository<BuyCartDetail, BuyCartDetailViewModel, MainDbContext>, IBuyCartDetailsService
    {
        private MainDbContext _context;
        private readonly IMapper _mapper;

        public BuyCartDetailsService(MainDbContext context, IMapper mapper) : base(context, mapper)
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

    }
}
