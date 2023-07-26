using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Abstract;
using TrenIstasyonlar.DataAccess.Concrete;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlari.Business.Services;

namespace TrenIstasyonlari.Business.Managers
{
    public class KullaniciManager : IKullaniciService
    {
        private readonly IKullaniciDAL _kullaniciDal;
        private IKullaniciService _kullaniciServiceImplementation;

        public KullaniciManager(IKullaniciDAL kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }


        public async Task<Kullanici> Register(Kullanici kullanici)
        {
            var user = _kullaniciDal.AddAsync(kullanici);
            return await user;
        }

        public Kullanici Login(Kullanici kullanici)
        {
            var userCheck =
                _kullaniciDal.Get(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre);
            return userCheck == null
                ? null
                : userCheck;
        }

        public Task<Kullanici> GetUser(Expression<Func<Kullanici, bool>> filter = null)
        {
            return _kullaniciDal.GetAsync(filter);
        }

        public Task<List<Kullanici>> GetList(Expression<Func<Kullanici,bool>> filter = null)
        {
            return _kullaniciDal.GetListAsync(filter);
        }

        public Kullanici Update(Kullanici kullanici)
        {
	        return _kullaniciDal.Update(kullanici);
        }

        public async Task<bool> Delete(Kullanici entity)
        {
            return await _kullaniciDal.DeleteAsync(entity);
        }
    }
}
