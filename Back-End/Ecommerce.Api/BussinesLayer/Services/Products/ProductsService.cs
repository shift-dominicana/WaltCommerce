using AutoMapper;
using BussinesLayer.Interfaces.Products;
using BussinesLayer.Repositories.Core;
using DataLayer.Contexts;
using Common.Models.Products;
using DataLayer.ViewModels.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BussinesLayer.Services.Products
{
    public class ProductsService : Repository<Product, ProductViewModel, MainDbContext>, IProductsService
    {

        private MainDbContext _context;

        public ProductsService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.Include(prod => prod.ProductImages).ToListAsync();
            return products;
        }

    }
}
