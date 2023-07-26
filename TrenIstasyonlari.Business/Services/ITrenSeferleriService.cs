using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Entities;

namespace TrenIstasyonlari.Business.Services
{
    public interface ITrenSeferleriService
    {
        Task<Sefer> Add(Sefer sefer);
        Task<List<Sefer>> GetSeferList(Expression<Func<Sefer,bool>> filter=null);
        Sefer Update(Sefer sefer);
        Task<bool> Delete(Sefer sefer);
        Sefer Get(Expression<Func<Sefer, bool>> filter = null);
        bool UpdateTime(DateTime departure, DateTime arrvive);
    }
}
