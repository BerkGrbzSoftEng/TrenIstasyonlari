using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrenIstasyonlar.DataAccess.Abstract;
using TrenIstasyonlar.DataAccess.Context;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlar.DataAccess.GenericRepository;

namespace TrenIstasyonlar.DataAccess.Concrete
{
	public class EfKullaniciDAL : EfEntityRepositoryBase<Kullanici, TrenIstasyonlariDbContext>, IKullaniciDAL
	{
		private readonly TrenIstasyonlariDbContext _dbContext;
		public EfKullaniciDAL(TrenIstasyonlariDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}


        

        public Kullanici Update(Kullanici kullanici)
		{
			var user = _dbContext.Kullanicis.Where(x => x.KullaniciId == kullanici.KullaniciId).FirstOrDefault();
			var update = _dbContext.Kullanicis.Update(new Kullanici()
			{
				KullaniciAdi = kullanici.KullaniciAdi,
				KullaniciId = user.KullaniciId,
				Sifre = kullanici.Sifre
			});
			_dbContext.SaveChanges();
			return user;
		}
	}
}
