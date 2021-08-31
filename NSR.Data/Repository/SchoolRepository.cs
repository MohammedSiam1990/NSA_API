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
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public List<School> GetSchools()
        {
            var School = base.Table().ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return School;
        }

        public School GetSchool(int InsertedBy)
        {
            var School = base.Table().Where(e => e.InsertedBy == InsertedBy).FirstOrDefault();

            base.DbContext.Dispose();
            base.DbContext = null;
            return School;
        }

        public School GetSchoolID(int SchoolID)
        {
            var School = base.Table().Where(e => e.SchoolId == SchoolID).FirstOrDefault();

            base.DbContext.Dispose();
            base.DbContext = null;
            return School;
        }


        public void AddSchool(School School)
        {
            School.CreateDate = DateTime.Now;
            Add(School);
        }
        public void UpdateSchool(School School)
        {
            School.LastModifyDate = DateTime.Now;
            Update(School);
        }
        public int SaveSchool(School School, string Img)
        {

            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (School.SchoolId == 0)
                    {
                        School.CreateDate = DateTime.Now;
                        context.Add(School);
                    }
                    if (School.SchoolId > 0)
                    {
                        School.LastModifyDate = DateTime.Now;

                        if (School.ApprovedBy > 0 && School.ApprovedBy != null && School.ManagementAction == 4)
                        {
                            School.ApprovedDate = DateTime.Now;
                        }
                        context.Update(School);
                    }
                    context.SaveChanges();
                    transaction.Commit();
                }
                return 1;

            }
        }

        public void DeleteSchool(int SchoolId)
        {
            Delete(SchoolId);
        }

        public School ValidateAlreadyExist(School model)
        {
            return GetById(e => e.SchoolId != model.SchoolId && (e.SchoolName1 == model.SchoolName1 || e.SchoolName2 == model.SchoolName2 ||
            e.SchoolName3 == model.SchoolName3 || e.SchoolName4 == model.SchoolName4 || e.SchoolNameEN == model.SchoolNameEN));
        }


        [Obsolete]
        public string GetProSchoolsAll()
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetSchoolsAll ";
                var data = DbContext.JsonData.FromSql(Sql).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }
    }
}
