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
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public List<University> GetUniversitys()
        {
            var University = base.Table().ToList(); 
            base.DbContext.Dispose();
            base.DbContext = null;
            return University;
        }
        
        public University GetUniversity(int InsertedBy)
        {
            var University = base.Table().Where(e => e.InsertedBy == InsertedBy).FirstOrDefault();
 
            base.DbContext.Dispose();
            base.DbContext = null;
            return University;
        }


        public University GetUniversityID(int UniversityID)
        {
            var University = base.Table().Where(e => e.UniversityId == UniversityID).FirstOrDefault();

            base.DbContext.Dispose();
            base.DbContext = null;
            return University;
        }


        public void AddUniversity(University University)
        {
            University.CreateDate = DateTime.Now;
            Add(University);
        }
        public void UpdateUniversity(University University)
        {
            University.LastModifyDate = DateTime.Now;
            Update(University);
        }
        public int SaveUniversity(University University, string Img)
        {

            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (University.UniversityId == 0) 
                    {
                        University.CreateDate = DateTime.Now;
                        context.Add(University);
                     }
                    if (University.UniversityId > 0)
                    {
                        University.LastModifyDate = DateTime.Now;

                        if (University.ApprovedBy > 0  && University.ApprovedBy != null  && University.ManagementAction == 4)
                        {
                            University.ApprovedDate = DateTime.Now;
                        }
                        context.Update(University);
                    }
                    context.SaveChanges();
                    transaction.Commit();
                }
                return 1;

            }
        }

        public void DeleteUniversity(int UniversityId)
        {
            Delete(UniversityId);
        }

        public University ValidateAlreadyExist(University model)
        {
            return GetById(e => e.UniversityId != model.UniversityId  && (e.UniversityName1 == model.UniversityName1 || e.UniversityName2 == model.UniversityName2 ||
            e.UniversityName3 == model.UniversityName3 || e.UniversityName4 == model.UniversityName4 || e.UniversityNameEN == model.UniversityNameEN));
        }


        [Obsolete]
        public string GetProUniversitysAll()
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetUniversitysAll ";
                var data = DbContext.JsonData.FromSql(Sql).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }


    }
}
