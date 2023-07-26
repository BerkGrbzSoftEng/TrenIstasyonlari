using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrenIstasyonlar.DataAccess.GenericRepository
{
    public interface IEntityRepository<T> where T:class,new()
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddAsync(List<T> entity);
         T  Update(T entity); 
        Task<bool> DeleteAsync(T entity);

        T Get(Expression<Func<T, bool>> filter = null);
    }
}
