using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.Products;
using DataLayer.Contexts;
using DataLayer.ViewModels.Products;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ProductService : Repository<Product, ProductViewModel, MainDbContext>, IProductService
    {

        private MainDbContext _context;

        public ProductService(MainDbContext context, IMapper mapper) : base(context, mapper)
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
