using BussinesLayer.Repositories.Core;
using Common.Models.ProductsSpecifications;
using DataLayer.ViewModels.ProductsSpecifications;

namespace BussinesLayer.Interfaces
{
    public interface IProductSpecificationService : IRepository<ProductSpecification, ProductSpecificationViewModel>
    {

    }
}
