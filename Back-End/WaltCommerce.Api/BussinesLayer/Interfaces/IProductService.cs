using BussinesLayer.Repositories.Core;
using Common.Models.Products;
using DataLayer.ViewModels.Products;


namespace BussinesLayer.Interfaces
{
    public interface IProductService : IRepository<Product, ProductViewModel>
    {
        
    }
}
