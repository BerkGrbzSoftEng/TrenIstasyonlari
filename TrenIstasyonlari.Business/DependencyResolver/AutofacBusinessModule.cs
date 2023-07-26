using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TrenIstasyonlar.DataAccess.Abstract;
using TrenIstasyonlar.DataAccess.Concrete;
using TrenIstasyonlari.Business.Managers;
using TrenIstasyonlari.Business.Services;

namespace TrenIstasyonlari.Business.DependencyResolver
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            builder.RegisterType<EfKullaniciDAL>().As<IKullaniciDAL>();

            builder.RegisterType<IstasyonManager>().As<IIstasyonService>();
            builder.RegisterType<EfIstasyonDAL>().As<IIstasyonDAL>();

            builder.RegisterType<TrenSeferleriManager>().As<ITrenSeferleriService>();
            builder.RegisterType<EfSeferDAL>().As<ISeferDAL>();
        }
    }
}
