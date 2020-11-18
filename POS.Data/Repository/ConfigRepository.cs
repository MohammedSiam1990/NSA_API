﻿using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Repository
{
    public class ConfigRepository : Repository<Config>, IConfigRepository
    {
        public ConfigRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void SaveConfig(List<Config> Added, List<Config> Updated)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        base.UpdateRange(Updated);
                        base.AddRange(Added);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new AppException(ex.Message);
                    }
                }
            }

        }
    }
}
