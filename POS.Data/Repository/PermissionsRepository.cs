﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class PermissionsRepository : Repository<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetPermissionsLookUps(int MenuType)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetPermissionsLookups @MenuType";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@MenuType", MenuType))
                    .AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }

        public void SavePermissions(List<Permissions> model,int RoleID)
        {
            var Permission = GetMany(e => e.RoleID == RoleID).ToList();
            DeleteRange(Permission);
            AddRange(model);
        }
    }
}
