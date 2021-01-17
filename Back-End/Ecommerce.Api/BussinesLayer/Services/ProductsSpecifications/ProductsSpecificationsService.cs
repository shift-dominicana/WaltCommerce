using AutoMapper;
using BussinesLayer.Interfaces.ProductsSpecifications;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductsSpecifications;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsSpecifications;

namespace BussinesLayer.Services.ProductsSpecifications
{
    public class ProductsSpecificationsService : Repository<ProductSpecification, ProductSpecificationViewModel, MainDbContext>, IProductsSpecificationsService
    {
        private MainDbContext _context;

        public ProductsSpecificationsService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

    }
}
