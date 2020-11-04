using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Dto.Procedure;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class RemarksTemplateRepository : Repository<RemarksTemplate>, IRemarksTemplateRepository
    {
        public RemarksTemplateRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void AddRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            try
            {
                remarksTemplate.CreateDate = DateTime.Now;
                Add(remarksTemplate);
                //  PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        [Obsolete]
        public string GetProcRemarksTemplate(int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetRemarksTemplateData @BrandID";
                    var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID)).AsEnumerable().FirstOrDefault().Data;

                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }
        }

        public void UpdateRemarksTemplate(RemarksTemplate remarksTemplate, List<RemarksTemplateDetails> DeletRemarksTemplateDetails)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        
                        context.RemoveRange(DeletRemarksTemplateDetails);
                        remarksTemplate.ModifyDate = DateTime.Now;
                        context.Update(remarksTemplate);

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

        public int ValidateNameAlreadyExist(RemarksTemplate model)
        {

            var remarksTemplate = GetById(e => e.RemarksTemplateId != model.RemarksTemplateId && (e.RemarksTemplateName == model.RemarksTemplateName
            || e.RemarksTemplateNameAr == model.RemarksTemplateNameAr)
            );

            if (remarksTemplate == null) return 1;

            if (remarksTemplate.RemarksTemplateName == model.RemarksTemplateName)
                return -2;
            else if (remarksTemplate.RemarksTemplateNameAr == model.RemarksTemplateNameAr)
                return -3;
            return 1;
        }

        public bool ValidateRemarkTemplate(RemarksTemplate remarksTemplate)
        {
            try
            {
                if (remarksTemplate.RemarksTemplateName != "" || remarksTemplate.RemarksTemplateNameAr != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }
}
