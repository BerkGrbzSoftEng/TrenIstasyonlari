using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Entities;

namespace TrenIstasyonlari.Business.Services
{
    public interface IIstasyonService
    {
        Task<Istasyon> AddAsync(Istasyon entity);
        Task<List<Istasyon>> GetAllAsync(Expression<Func<Istasyon,bool>> filter=null);
        Task<bool> Delete(Istasyon entity);
        Istasyon Update(Istasyon entity);
        Task<Istasyon> Get(Expression<Func<Istasyon, bool>> filter = null);
    }
}
