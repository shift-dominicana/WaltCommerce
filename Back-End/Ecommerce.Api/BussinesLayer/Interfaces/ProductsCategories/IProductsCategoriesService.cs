using BussinesLayer.Repositories.Core;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces.ProductsCategories
{
    public interface IProductsCategoriesService : IRepository<ProductCategory, ProductCategoryViewModel>
    {
        public Task<IEnumerable<ProductCategory>> GetListProduct();
    }
}
