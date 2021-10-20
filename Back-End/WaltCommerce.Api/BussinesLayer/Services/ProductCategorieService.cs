using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductCategories;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsCategories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ProductCategorieService : Repository<ProductCategory, ProductCategoryViewModel, MainDbContext>, IProductCategorieService
    {

        private MainDbContext _context;

        public ProductCategorieService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            var products = await _context.ProductsCategories.Where(p => p.IsDeleted == false)
            .Include(p => p.Products)
            .ThenInclude(p => p.ProductImages)
            .Include(p => p.Products)
            .ThenInclude(p => p.Specs)
            .Include(p => p.Products)
            .ThenInclude(p => p.ProductColor).ToListAsync();


            return products;
        }

    }
}
