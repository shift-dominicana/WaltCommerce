using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BussinesLayer.Repositories.Core
{
    public class Repository<TModel, TViewModel, TContext> : 
        IRepository<TModel, TViewModel> 
        where TModel : class
        where TViewModel : class
        where TContext : DbContext
    {

        private readonly DbSet<TModel> _dbSet;
        private readonly TContext _context;
        private readonly IMapper _mapper;

        public Repository(TContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
            _mapper = mapper;
        }

        public TModel Add(TModel entity)
        {
            return _context.Add(entity).Entity;
        }

        public async Task AddAsync(TModel entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<TModel> GeTModelByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public async Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);

        public bool Any(Expression<Func<TModel, bool>> predicate)
            => _dbSet.Any(predicate);

        public async Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public virtual async Task<IEnumerable<TModel>> GetAllAsync() => await _dbSet.ToListAsync();
        public IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TModel> query = _dbSet.Where(predicate);
            return query;
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate)
            => await _dbSet.Where(predicate).FirstOrDefaultAsync();

        public IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate) =>
             _dbSet.Where(predicate).AsQueryable();

        public IQueryable<TModel> GetQueryable() => _dbSet.AsQueryable();

        public TModel UpdateEntity(TModel entity)
        {
            return _context.Update(entity).Entity;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            var type = entity.GetType();
            var prop = type.GetProperty("IsDeleted");
            prop?.SetValue(entity, true);
            return await CommitAsync();
        }

        public void DeleteByEntity(TModel entity)
        {
            var type = entity.GetType();
            var prop = type.GetProperty("IsDeleted");
            prop?.SetValue(entity, true);
        }


        public void RemoveRange(IEnumerable<TModel> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }


        public async Task<bool> CommitAsync()
        {

            try
            {
                var savedRegistries = await _context.SaveChangesAsync();
                bool succeeded = savedRegistries > 0;
                return succeeded;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }
        public virtual async Task<TViewModel> CreateAsync(TModel entity)
        {
            await _context.AddAsync(entity);
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<TViewModel>(entity);
                return mapped;
            }
            return null;
        }

        public virtual async Task<TViewModel> EditAsync(TModel model)
        {
            var updated = _context.Update(model).Entity;
            if (await CommitAsync())
            {
                var mapped = _mapper.Map<TViewModel>(updated);
                return mapped;
            }
            return null;
        }
    }
}
