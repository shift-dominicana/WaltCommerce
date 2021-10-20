using BussinesLayer.Repositories.Core;
using Common.Models.Brands;
using DataLayer.ViewModels.Brands;

namespace BussinesLayer.Interfaces
{
    public interface IBrandService : IRepository<Brand, BrandViewModel>
    {

    }
}
