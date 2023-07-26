using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlar.DataAccess.GenericRepository;

namespace TrenIstasyonlar.DataAccess.Abstract
{
    public interface IIstasyonDAL : IEntityRepository<Istasyon>
    {
    }
}
