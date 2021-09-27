using AutoMapper;
using BussinesLayer.Interfaces.ProductsSizes;
using BussinesLayer.Repositories.Core;
using Common.Models.Sizes;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsSizes;

namespace BussinesLayer.Services.ProductsSizes
{
    public class ProductsSizesService : Repository<ProductSize, ProductSizeViewModel, MainDbContext>, IProductsSizesService
    {
        private MainDbContext _context;

        public ProductsSizesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
