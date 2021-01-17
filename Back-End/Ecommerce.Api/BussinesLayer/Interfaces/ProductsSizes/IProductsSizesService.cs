using BussinesLayer.Repositories.Core;
using Common.Models.Sizes;
using DataLayer.ViewModels.ProductsSizes;

namespace BussinesLayer.Interfaces.ProductsSizes
{
    public interface IProductsSizesService : IRepository<ProductSize, ProductSizeViewModel>
    {

    }
}
