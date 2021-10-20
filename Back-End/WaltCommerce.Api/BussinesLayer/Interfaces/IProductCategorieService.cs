using BussinesLayer.Repositories.Core;
using Common.Models.ProductCategories;
using DataLayer.ViewModels.ProductsCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IProductCategorieService : IRepository<ProductCategory, ProductCategoryViewModel>
    {

    }
}
