using AutoMapper;
using BussinesLayer.Interfaces.ProductsColors;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductsColors;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsColors;

namespace BussinesLayer.Services.ProductsColors
{

    public class ProductsColorsService : Repository<ProductColor, ProductColorViewModel, MainDbContext>, IProductsColorsService
    {
        private MainDbContext _context;

        public ProductsColorsService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}
