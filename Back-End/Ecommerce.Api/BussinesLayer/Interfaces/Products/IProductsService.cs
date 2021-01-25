using BussinesLayer.Repositories.Core;
using Common.Models.Products;
using DataLayer.ViewModels.Products;


namespace BussinesLayer.Interfaces.Products
{
    public interface IProductsService : IRepository<Product, ProductViewModel>
    {
        
    }
}
