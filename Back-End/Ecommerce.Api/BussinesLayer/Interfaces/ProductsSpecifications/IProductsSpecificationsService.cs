using BussinesLayer.Repositories.Core;
using Common.Models.ProductsSpecifications;
using DataLayer.ViewModels.ProductsSpecifications;

namespace BussinesLayer.Interfaces.ProductsSpecifications
{
    public interface IProductsSpecificationsService : IRepository<ProductSpecification, ProductSpecificationViewModel>
    {

    }
}
