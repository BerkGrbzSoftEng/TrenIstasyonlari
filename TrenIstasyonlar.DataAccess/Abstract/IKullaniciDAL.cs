using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlar.DataAccess.GenericRepository;

namespace TrenIstasyonlar.DataAccess.Abstract
{
    public interface IKullaniciDAL:IEntityRepository<Kullanici>
    { 
        Kullanici Update(Kullanici kullanici);
    }
}
