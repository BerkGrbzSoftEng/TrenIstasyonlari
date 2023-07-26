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
    public class IstasyonManager : IIstasyonService
    {
        private readonly IIstasyonDAL _istasyonDal;

        public IstasyonManager(IIstasyonDAL istasyonDal)
        {
            _istasyonDal = istasyonDal;
        }


        public Task<Istasyon> AddAsync(Istasyon entity)
        {
            return _istasyonDal.AddAsync(entity);
        }

        public async Task<List<Istasyon>> GetAllAsync(Expression<Func<Istasyon, bool>> filter = null)
        {
            return await _istasyonDal.GetListAsync(filter);
        }

        public async Task<bool> Delete(Istasyon entity)
        {
            return await _istasyonDal.DeleteAsync(entity);
        }

        public Istasyon Update(Istasyon entity)
        {
            return _istasyonDal.Update(entity);
        }

        public Task<Istasyon> Get(Expression<Func<Istasyon, bool>> filter = null)
        {
            return _istasyonDal.GetAsync(filter);
        }
    }
}
