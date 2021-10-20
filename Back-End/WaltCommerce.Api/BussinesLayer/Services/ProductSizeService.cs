using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.Sizes;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsSizes;

namespace BussinesLayer.Services
{
    public class ProductSizeService : Repository<ProductSize, ProductSizeViewModel, MainDbContext>, IProductSizeService
    {
        private MainDbContext _context;

        public ProductSizeService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
