using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Entities;

namespace TrenIstasyonlari.Business.Services
{
    public interface IKullaniciService
    {
        Task<Kullanici> Register(Kullanici kullanici);
        Kullanici Login(Kullanici kullanici);
        Task<Kullanici> GetUser(Expression<Func<Kullanici,bool>> filter=null);
        Task<List<Kullanici>> GetList(Expression<Func<Kullanici,bool>> filter = null);
        Kullanici Update(Kullanici kullanici);
        Task<bool> Delete(Kullanici entity);

    }
}
