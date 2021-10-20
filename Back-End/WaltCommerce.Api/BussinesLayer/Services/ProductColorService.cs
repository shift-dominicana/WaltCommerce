using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductsColors;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsColors;

namespace BussinesLayer.Services
{

    public class ProductColorService : Repository<ProductColor, ProductColorViewModel, MainDbContext>, IProductColorService
    {
        private MainDbContext _context;

        public ProductColorService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
