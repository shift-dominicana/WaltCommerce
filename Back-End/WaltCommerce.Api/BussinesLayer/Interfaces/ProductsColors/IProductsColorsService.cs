using BussinesLayer.Repositories.Core;
using Common.Models.ProductsColors;
using DataLayer.ViewModels.ProductsColors;

namespace BussinesLayer.Interfaces.ProductsColors
{
    public interface IProductsColorsService : IRepository<ProductColor, ProductColorViewModel>
    {

    }
}
