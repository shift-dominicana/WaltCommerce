using BussinesLayer.Repositories.Core;
using Common.Models.Brands;
using DataLayer.ViewModels.Brands;

namespace BussinesLayer.Interfaces.Brands
{
    public interface IBrandsService : IRepository<Brand, BrandViewModel>
    {

    }
}
