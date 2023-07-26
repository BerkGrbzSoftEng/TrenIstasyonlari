using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TrenIstasyonlar.DataAccess.Context
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<TrenIstasyonlariDbContext>
    {
        public TrenIstasyonlariDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TrenIstasyonlariDbContext>();
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TrenIstasyonlari"))
                .AddJsonFile("appsettings.json")
                .Build();
            builder.UseSqlServer(config.GetConnectionString("SqlServer"));
            return new TrenIstasyonlariDbContext(builder.Options);
        }
    }
}
