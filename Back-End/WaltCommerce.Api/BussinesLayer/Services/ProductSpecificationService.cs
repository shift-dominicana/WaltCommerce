using AutoMapper;
using BussinesLayer.Interfaces;
using BussinesLayer.Repositories.Core;
using Common.Models.ProductsSpecifications;
using DataLayer.Contexts;
using DataLayer.ViewModels.ProductsSpecifications;

namespace BussinesLayer.Services
{
    public class ProductSpecificationService : Repository<ProductSpecification, ProductSpecificationViewModel, MainDbContext>, IProductSpecificationService
    {
        private MainDbContext _context;

        public ProductSpecificationService(MainDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

    }
}
