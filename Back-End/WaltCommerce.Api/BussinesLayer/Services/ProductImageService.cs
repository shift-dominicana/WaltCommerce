using AutoMapper;
using BussinesLayer.Interfaces.ProductsImages;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductsImages;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsImages;

namespace BussinesLayer.Services
{
    public class ProductImageService : Repository<ProductImage, ProductImageViewModel, MainDbContext>, IProductImageService
    {
        private MainDbContext _context;

        public ProductImageService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;

        }
    }
}
