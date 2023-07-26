﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenIstasyonlar.DataAccess.Abstract;
using TrenIstasyonlar.DataAccess.Context;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlar.DataAccess.GenericRepository;

namespace TrenIstasyonlar.DataAccess.Concrete
{
    public class EfSeferDAL:EfEntityRepositoryBase<Sefer,TrenIstasyonlariDbContext>,ISeferDAL
    {
        public EfSeferDAL(TrenIstasyonlariDbContext dbContext) : base(dbContext)
        {
        }
    }
}
