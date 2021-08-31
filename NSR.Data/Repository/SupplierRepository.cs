using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSR.Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetSupplier(int CompanyID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetSupplier @CompanyID";
                var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@CompanyID", CompanyID )
                   ).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }

        }

        public void SaveSupplier(Supplier model)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (model.SupplierID == 0)
                    {
                        model.CreateDate = DateTime.Now;
                        Add(model);
                        transaction.Commit();
                    }
                    else
                    {
                        model.LastModifyDate = DateTime.Now;
                        Update(model);
                        transaction.Commit();

                    }

                }
            }
        }

        public int ValidateNameAlreadyExist(Supplier model)
        {
            var PriceTemplate = GetById(e => e.SupplierID != model.SupplierID && (e.SupplierName == model.SupplierName
            || e.SupplierNameAr == model.SupplierNameAr));

            if (PriceTemplate == null) return 1;

            if (PriceTemplate.SupplierName == model.SupplierName)
                return -2;
            else if (PriceTemplate.SupplierNameAr == model.SupplierNameAr)
                return -3;
            return 1;

        }
    }
}
