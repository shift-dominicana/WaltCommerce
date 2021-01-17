using AutoMapper;
using BussinesLayer.Interfaces.ProductsImages;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductsImages;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsImages;

namespace BussinesLayer.Services.ProductsImages
{
    public class ProductsImagesService : Repository<ProductImage, ProductImageViewModel, MainDbContext>, IProductsImagesService
    {
        private MainDbContext _context;

        public ProductsImagesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;

        }
    }
}
