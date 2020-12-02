using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
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
    public class PriceTemplateRepository : Repository<PriceTemplate>, IPriceTemplateRepository
    {
        public PriceTemplateRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetPriceTemlate(int PriceTemplateID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetPriceTemplate @PriceTemplateID";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@PriceTemplateID", PriceTemplateID)).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }

        public void SavePriceTemplate(PriceTemplate model)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
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
                    catch (Exception ex)
                    {
                        throw new AppException(ex.Message);
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
