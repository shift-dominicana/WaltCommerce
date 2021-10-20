using BussinesLayer.Repositories.Core;
using Common.Models.ProductsImages;
using DataLayer.ViewModels.ProductsImages;

namespace BussinesLayer.Interfaces.ProductsImages
{
    public interface IProductImageService : IRepository<ProductImage, ProductImageViewModel>
    {

    }
}
