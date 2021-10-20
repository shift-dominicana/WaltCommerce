using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.Brands;
using DataLayer.Contexts;
using DataLayer.ViewModels.Brands;

namespace BussinesLayer.Services
{
    public class BrandService : Repository<Brand, BrandViewModel, MainDbContext>, IBrandService
    {
        private MainDbContext _context;

        public BrandService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
