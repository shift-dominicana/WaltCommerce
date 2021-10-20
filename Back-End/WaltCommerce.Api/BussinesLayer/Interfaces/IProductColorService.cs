using BussinesLayer.Repositories.Core;
using Common.Models.ProductsColors;
using DataLayer.ViewModels.ProductsColors;

namespace BussinesLayer.Interfaces
{
    public interface IProductColorService : IRepository<ProductColor, ProductColorViewModel>
    {

    }
}
