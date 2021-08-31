using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
{
    public class RemarksTemplateRepository : Repository<RemarksTemplate>, IRemarksTemplateRepository
    {
        public RemarksTemplateRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public int AddRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            remarksTemplate.CreateDate = DateTime.Now;
            Add(remarksTemplate);
            return remarksTemplate.RemarksTemplateId;
        }

        [Obsolete]
        public string GetProcRemarksTemplate(int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetRemarksTemplateData @BrandID";
                var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID)).AsEnumerable().FirstOrDefault().Data;

                return data.ToString();

            }
        }

        public void UpdateRemarksTemplate(RemarksTemplate remarksTemplate, List<RemarksTemplateDetails> DeletRemarksTemplateDetails)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {

                    context.RemoveRange(DeletRemarksTemplateDetails);
                    remarksTemplate.ModifyDate = DateTime.Now;
                    context.Update(remarksTemplate);

                    context.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        public int ValidateNameAlreadyExist(RemarksTemplate model)
        {

            var remarksTemplate = GetById(e => e.RemarksTemplateId != model.RemarksTemplateId && (e.RemarksTemplateName == model.RemarksTemplateName
            || e.RemarksTemplateNameAr == model.RemarksTemplateNameAr) && e.BrandId == model.BrandId && e.StatusId != 3
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
            if (remarksTemplate.RemarksTemplateName != "" || remarksTemplate.RemarksTemplateNameAr != "")
                return true;
            else
                return false;
        }
    }
}
