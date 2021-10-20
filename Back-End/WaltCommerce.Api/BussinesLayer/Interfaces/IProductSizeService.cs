using BussinesLayer.Repositories.Core;
using Common.Models.Sizes;
using DataLayer.ViewModels.ProductsSizes;

namespace BussinesLayer.Interfaces
{
    public interface IProductSizeService : IRepository<ProductSize, ProductSizeViewModel>
    {

    }
}
