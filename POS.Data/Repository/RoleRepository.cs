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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetRole(int? CompanyId)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetRole @CompanyID";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@CompanyID", CompanyId ?? (object)DBNull.Value)
                                                           ).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }

        public Role GetRoleById(int RoleId)
        {
            var Role = base.Table().Where(e => e.Id == RoleId).FirstOrDefault();
            base.DbContext.Dispose();
            base.DbContext = null;
            return Role;
        }

        public int RoleAlreadyExists(Role model)
        {
            var Role = GetById(e => e.Id != model.Id && e.CompanyId == model.CompanyId && (e.NameAr == model.NameAr || e.Name == model.Name));
            if (Role == null) return 1;
            else if (Role.Name == model.Name) return -2;
            else if (Role.NameAr == model.NameAr) return -3;
            else return -1;
        }

        public void SaveRole(Role model)
        {
            if (model.Id == 0)
            {
                model.CreateDate = DateTime.Now;
                Add(model);

            }
            else
            {
                model.LastModifyDate = DateTime.Now;
                Update(model);
            }
        }
    }
}
