using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Linq;

namespace POS.Data.Repository
{
    public class PriceTemplateRepository : Repository<PriceTemplate>, IPriceTemplateRepository
    {
        public PriceTemplateRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetPriceTemlate(int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetPriceTemplate @BrandID";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@BrandID", BrandID))
                    .AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }

        }

        public void SavePriceTemplate(PriceTemplate model)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (model.PriceTemplateID == 0)
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

        public int ValidateNameAlreadyExist(PriceTemplate model)
        {
            var PriceTemplate = GetById(e => e.PriceTemplateID != model.PriceTemplateID && (e.Name == model.Name
            || e.NameAr == model.NameAr) && e.BrandID == model.BrandID
          );

            if (PriceTemplate == null) return 1;

            if (PriceTemplate.Name == model.Name)
                return -2;
            else if (PriceTemplate.NameAr == model.NameAr)
                return -3;
            return 1;

        }
    }
}
