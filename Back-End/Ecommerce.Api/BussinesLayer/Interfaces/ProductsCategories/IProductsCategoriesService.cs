using BussinesLayer.Repositories.Core;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;

namespace BussinesLayer.Interfaces.ProductsCategories
{
    public interface IProductsCategoriesService : IRepository<ProductCategory, ProductCategoryViewModel>
    {

    }
}
