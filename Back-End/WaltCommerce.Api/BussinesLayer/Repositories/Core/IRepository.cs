using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BussinesLayer.Repositories.Core
{
    public interface IRepository<TModel, TViewModel> where TModel : class where TViewModel : class 
    {
        TModel Add(TModel entity);
        Task AddAsync(TModel entity);
        TModel UpdateEntity(TModel entity);

        Task<TModel> GeTModelByIdAsync(int id);
        Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> predicate);

        Task<IEnumerable<TModel>> GetAllAsync();
        IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate);

        Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate);

        IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> GetQueryable();

        Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate);
        bool Any(Expression<Func<TModel, bool>> predicate);

        Task<bool> DeleteByIdAsync(int id);
        void DeleteByEntity(TModel entity);

        void RemoveRange(IEnumerable<TModel> entities);
        bool Commit();

        Task<bool> CommitAsync();

        Task<TViewModel> CreateAsync(TModel entity);

        Task<TViewModel> EditAsync(TModel model);
    }
}