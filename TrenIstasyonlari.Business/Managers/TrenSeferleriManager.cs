using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Abstract;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlari.Business.Services;

namespace TrenIstasyonlari.Business.Managers
{
    public class TrenSeferleriManager:ITrenSeferleriService
    {
        private readonly ISeferDAL _seferDal;

        public TrenSeferleriManager(ISeferDAL seferDal)
        {
            _seferDal = seferDal;
        }

        public async Task<Sefer> Add(Sefer sefer)
        {
            return await _seferDal.AddAsync(sefer);
        }

        public  async Task<List<Sefer>> GetSeferList(Expression<Func<Sefer, bool>> filter = null)
        {
            return await _seferDal.GetListAsync(filter);
        }

        public Sefer Update(Sefer sefer)
        {
            return _seferDal.Update(sefer);
        }

        public async Task<bool> Delete(Sefer sefer)
        {
            return await _seferDal.DeleteAsync(sefer);
        }

        public Sefer Get(Expression<Func<Sefer, bool>> filter = null)
        {
            return _seferDal.Get(filter);
        }

        public bool UpdateTime(DateTime departure, DateTime arrvive)
        {
            throw new NotImplementedException();
        }
    }
}
