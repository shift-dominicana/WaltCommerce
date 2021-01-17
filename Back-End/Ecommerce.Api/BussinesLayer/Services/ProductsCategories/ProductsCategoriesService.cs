using AutoMapper;
using BussinesLayer.Interfaces.ProductsCategories;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductCategories;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsCategories;

namespace BussinesLayer.Services.ProductsCategories
{
    public class ProductsCategoriesService : Repository<ProductCategory, ProductCategoryViewModel, MainDbContext>, IProductsCategoriesService
    {

        private MainDbContext _context;

        public ProductsCategoriesService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

    }
}
