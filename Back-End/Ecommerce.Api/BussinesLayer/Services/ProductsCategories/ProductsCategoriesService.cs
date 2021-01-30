using AutoMapper;
using BussinesLayer.Interfaces.ProductsCategories;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductCategories;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsCategories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services.ProductsCategories
{
    public class ProductsCategoriesService : Repository<ProductCategory, ProductCategoryViewModel, MainDbContext>, IProductsCategoriesService
    {

        private MainDbContext _context;

        public ProductsCategoriesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            var products = await _context.ProductsCategories.Include(p => p.Products)
                                                        .ThenInclude(p => p.ProductImages)
                                                            .Include(p => p.Products)
                                                        .ThenInclude(p => p.Specs).ToListAsync();
            return products;
        }

    }
}
