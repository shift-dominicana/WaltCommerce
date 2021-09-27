using AutoMapper;
using BussinesLayer.Interfaces.Brands;
using BussinesLayer.Repositories.Core;
using Common.Models.Brands;
using DataLayer.Contexts;
using DataLayer.ViewModels.Brands;

namespace BussinesLayer.Services.Brands
{
    public class BrandsService : Repository<Brand, BrandViewModel, MainDbContext>, IBrandsService
    {
        private MainDbContext _context;

        public BrandsService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
