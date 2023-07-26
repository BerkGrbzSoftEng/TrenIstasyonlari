using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrenIstasyonlar.DataAccess.Context;

namespace TrenIstasyonlar.DataAccess.GenericRepository
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly TrenIstasyonlariDbContext _dbContext;

        public EfEntityRepositoryBase(TrenIstasyonlariDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? await _dbContext.Set<TEntity>().ToListAsync()
                : await _dbContext.Set<TEntity>().Where(filter).ToListAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? await _dbContext.Set<TEntity>().SingleOrDefaultAsync()
                : await _dbContext.Set<TEntity>().Where(filter).SingleOrDefaultAsync();

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? _dbContext.Set<TEntity>().SingleOrDefault()
                : _dbContext.Set<TEntity>().Where(filter).SingleOrDefault();

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {

            var data = _dbContext.Set<TEntity>().AddAsync(entity);
            if (data.IsCompleted)
            {
                await _dbContext.SaveChangesAsync();
                return data.Result.Entity;
            }

            return null;
        }

        public Task<IEnumerable<TEntity>> AddAsync(List<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            var data = _dbContext.Set<TEntity>().Update(entity); 
            _dbContext.SaveChanges();
            if (data != null)
            {
                return data.Entity;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            var data = _dbContext.Set<TEntity>().Remove(entity);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
